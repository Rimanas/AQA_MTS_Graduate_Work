using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Fakers;
using AQA_MTS_Graduate_Work.Models;
using AQA_MTS_Graduate_Work.TestsUI;
using Bogus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NLog;
using System.Net;

namespace AQA_MTS_Graduate_Work.TestsApi
{
    [AllureSuite("API Tests")]
    public class MilestoneFakerTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private Project _project = null!;
        private Milestone _milestone = null!;
        private Section _section = null!;
        private static Faker<Project> Project => new ProjectFaker();
        private static Faker<Milestone> Milestone => new MilestoneFaker();
        private static Faker<Section> Section => new SectionFaker();

        [OneTimeSetUp]
        [Description("Pre-Condition:create project")]
        public void AddProjectTest()
        {
            _project = Project.Generate();

            _project = ProjectServices!.AddProject(_project).Result;
            //_logger.Info(_project.ToString());
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
        [Category("NFE Api Test")]
        [AllureFeature("API ADD Method")]
        [AllureDescription("Проверка Добавления Milestone")]
        [AllureOwner("Qa A")]
        public void AddMilestoneTest()
        {
            _milestone = Milestone.Generate();

            var actualMilestone = MilestoneServices!.AddMilestone(_project.Id.ToString(), _milestone);
            //var actualMilestone = MilestoneServices!.AddMilestone("7", _milestone);
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
        [Category("NFE Api Test")]
        [AllureFeature("API ADD Method")]
        [AllureDescription("Проверка Добавления Section")]
        [AllureOwner("Qa A")]
        public void AddSectionTest()
        {
            _section = Section.Generate();

            var actualSection = SectionServices!.AddSection(_project.Id.ToString(), _section);
            //var actualSection = SectionServices!.AddSection("7", _section);
            Assert.Multiple(() =>
            {
                Assert.That(actualSection.Result.Name, Is.EqualTo(_section.Name));
                Assert.That(actualSection.Result.Description, Is.EqualTo(_section.Description));
            });

            _section = actualSection.Result;

            _logger.Info(_section.ToString());
        }

        [Test]
        [Order(3)]
        [Category("NFE Api Test")]
        [AllureFeature("API GET Method")]
        [AllureDescription("Проверка метода GET Project")]
        [AllureOwner("Qa A")]
        public void GetProjectTest()
        {
            var actualProject = ProjectServices!.GetProject(_project.Id.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualProject.Result.Name, Is.EqualTo(_project.Name));
                Assert.That(actualProject.Result.Announcement, Is.EqualTo(_project.Announcement));
                Assert.That(actualProject.Result.ShowAnnouncement, Is.EqualTo(_project.ShowAnnouncement));
                Assert.That(actualProject.Result.SuiteMode, Is.EqualTo(_project.SuiteMode));
            });
            _project = actualProject.Result;
            _logger.Info(actualProject.Result.ToString());
        }

        [Test]
        [Order(4)]
        [Category("NFE Api Test")]
        [AllureFeature("API GET Method")]
        [AllureDescription("Проверка метода GET Milestone")]
        [AllureOwner("Qa A")]
        public void GetMilestoneTest()
        {
            var actualMilestone = MilestoneServices!.GetMilestone(_milestone.ID.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualMilestone.Result.Name, Is.EqualTo(_milestone.Name));
                Assert.That(actualMilestone.Result.Description, Is.EqualTo(_milestone.Description));
            });

            _logger.Info(actualMilestone.Result.ToString());
        }

        [Test]
        [Order(5)]
        [Category("NFE Api Test")]
        [AllureFeature("API GET Method")]
        [AllureDescription("Проверка метода GET Section")]
        [AllureOwner("Qa A")]
        public void GetSectionTest()
        {
            var actualSection = SectionServices!.GetSection(_section.Id.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualSection.Result.Name, Is.EqualTo(_section.Name));
                Assert.That(actualSection.Result.Description, Is.EqualTo(_section.Description));
            });

            _logger.Info(actualSection.Result.ToString());
        }

        [Test]
        [Order(6)]
        [Category("NFE Api Test")]
        [AllureFeature("API UPDATE Method")]
        [AllureDescription("Проверка метода UPDATE Milestone")]
        [AllureOwner("Qa A")]
        public void UpdateMilestoneTest()
        {
            Milestone milestoneUpdate = new Milestone
            {
                ID = _milestone.ID,
                Name = "New TestName"
            };

            var actualMilestone = MilestoneServices!.UpdateMilestone(milestoneUpdate);

            Assert.That(actualMilestone.Result.Name, Is.EqualTo(milestoneUpdate.Name));

            _milestone = actualMilestone.Result;
            _logger.Info(_milestone.ToString());
        }

        [Test]
        [Order(7)]
        [Category("NFE Api Test")]
        [AllureFeature("API DELETE Method")]
        [AllureDescription("Проверка метода DELETE Milestone")]
        [AllureOwner("Qa A")]
        public void DeleteMilestoneTest()
        {
            var actualMilestone = MilestoneServices!.DeleteMilestone(_milestone.ID.ToString());

            Assert.That(actualMilestone == HttpStatusCode.OK);
        }

        [Test]
        [Order(8)]
        [Category("AFE Api Test")]
        [AllureFeature("API GET Method")]
        [AllureDescription("Проверка метода GET Milestone After DELETE")]
        [AllureOwner("Qa A")]
        public void GetMilestoneWithIncorrectIdTest()
        {
            AllureApi.Step("All Milestones");
            var milestonesList = MilestoneServices!.GetMilestones(_project.Id.ToString());
            _logger.Info(milestonesList);
            var badRequestMilestone = MilestoneServices!.GetMilestone("-1");
            AllureApi.Step("Calling the Get Milestone with incorrect id");
            Assert.That(badRequestMilestone.Result.Error, Is.EqualTo("Field :milestone_id is not a valid milestone."));
            _logger.Info(badRequestMilestone);
        }

        [Test]
        [Order(9)]
        [Category("AFE Api Test")]
        [AllureFeature("API GET Method")]
        [AllureDescription("Проверка метода GET Milestone After DELETE")]
        [AllureOwner("Qa A")]
        public void GetProgectWithIncorrectIdTest()
        {
            AllureApi.Step("All Projects");
            var projectsList = ProjectServices!.GetProjects();
            _logger.Info(projectsList);
            var badRequestProject = ProjectServices!.GetProject("0");
            AllureApi.Step("Calling the Get Project with incorrect id");
            Assert.That(badRequestProject.Result.Error, Is.EqualTo("Field :project_id is not a valid or accessible project.")); //можно поменять, чтобы тест упал
            _logger.Info(badRequestProject);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Assert.That(ProjectServices!.DeleteProject(_project.Id.ToString()) == HttpStatusCode.OK);
        }


    }

}
