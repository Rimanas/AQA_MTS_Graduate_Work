using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Fakers;
using AQA_MTS_Graduate_Work.Models;
using Bogus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NLog;
using System.Net;

namespace AQA_MTS_Graduate_Work.TestsApi
{
    [AllureSuite("API Tests")]
    public class JsonTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private Project _project = null!;
        private Milestone _milestone = null!;
        private static Faker<Project> Project => new ProjectFaker();
        private static Faker<Milestone> Milestone => new MilestoneFaker();

        [OneTimeSetUp]
        [Description("Pre-Condition:create project")]
        public void CreateProject()
        {
            _project = Project.Generate();

            _project = ProjectServices!.AddProject(_project).Result;
            // Блок проверок
            Assert.Multiple(() =>
            {
                Assert.That(_project.Name, Is.EqualTo(_project.Name));
                Assert.That(_project.Announcement, Is.EqualTo(_project.Announcement));
                Assert.That(_project.SuiteMode, Is.EqualTo(_project.SuiteMode));
            });
            _logger.Info(_project.ToString());
        }

        [Test]
        [Order(1)]
        [Description("Step 1: Add Milestone to Project")]
        public void AddMilestoneJsonTest()
        {
            _milestone = Milestone.Generate();
            //Загрузка и создание Json схемы из файла
            string schemaJson = File.ReadAllText(@"Resources/schema.json");
            JSchema schema = JSchema.Parse(schemaJson);

            var actualMilestone = MilestoneServices!.AddMilestone(_project.Id.ToString(), _milestone);
            var addMilestoneResponse = MilestoneServices!.AddMilestoneResponse(_project.Id.ToString(), _milestone);
            //Проверка статуса
            Assert.That(addMilestoneResponse.Result.StatusCode == HttpStatusCode.OK);
            // Получаем тело ответа в виде JObject
            JObject responseData = JObject.Parse(addMilestoneResponse.Result.Content);
            // проверка соответсвия ответа Json схемы
            Assert.That(responseData.IsValid(schema));
            // проверка соответсвия данных
            Assert.Multiple(() =>
            {
                Assert.That(actualMilestone.Result.Name, Is.EqualTo(_milestone.Name));
                Assert.That(actualMilestone.Result.Description, Is.EqualTo(_milestone.Description));
            });
            _milestone = actualMilestone.Result;
            _logger.Info(_milestone.ToString());
        }

        [Test]
        [Order(2)]

        public void GetMilestoneFromJsonTest()
        {
            AllureApi.Step("TC is started");
            // Загрузка JSON из файла
            string milestoneJson = File.ReadAllText(@"Resources/MilestoneGetSchema.json");
            _logger.Info(milestoneJson);

            // Создем экземпляр объекта из JSON
            var _milestone = JsonConvert.DeserializeObject<Milestone>(milestoneJson);
            _logger.Info(_milestone);

            var milestone = MilestoneServices?.GetMilestoneResponse(_milestone.ID.ToString()).Result;
            //var milestone = MilestoneServices?.GetMilestone("7").Result;
            _logger.Info(milestone);

            AllureApi.Step("Response");
            Milestone actualMilestone = JsonConvert.DeserializeObject<Milestone>(milestone.Content);

            //проверка что после десериализации файла JSON в объект, его поля равны объекту после API запроса
            Assert.Multiple(() =>
            {
                Assert.That(actualMilestone.Name, Is.EqualTo(_milestone.Name));
                Assert.That(actualMilestone.ID, Is.EqualTo(_milestone.ID));
                Assert.That(milestone.StatusCode == HttpStatusCode.OK);
            });
            AllureApi.Step("Test выполнен.");
        }


        [OneTimeTearDown]
        [Description("Post-Condition : delete project")]
        public void OneTimeTearDown()
        {
            Assert.That(ProjectServices!.DeleteProject(_project.Id.ToString()) == HttpStatusCode.OK);
        }
    }

}
