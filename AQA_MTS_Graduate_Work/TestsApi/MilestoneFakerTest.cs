using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Fakers;
using AQA_MTS_Graduate_Work.Models;
using Bogus;
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
        private static Faker<Project> Project => new ProjectFaker();
        private static Faker<Milestone> Milestone => new MilestoneFaker();

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
        public void AddMilestoneTest()
        {
            _milestone = Milestone.Generate();

            var actualMilestone = MilestoneServices!.AddMilestone(_project.Id.ToString(), _milestone);
            Assert.Multiple(() =>
            {
                Assert.That(actualMilestone.Result.Name, Is.EqualTo(_milestone.Name));
                Assert.That(actualMilestone.Result.Description, Is.EqualTo(_milestone.Description));
            });

            _milestone = actualMilestone.Result;

            _logger.Info(_milestone.ToString());
        }

        [Test]
        [Order(1)]
        public void AddSectionTest()
        {
            _section = Section.Generate();

            var actualMilestone = MilestoneServices!.AddMilestone(_project.Id.ToString(), _milestone);
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
        [Order(3)]
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
        [Order(4)]
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
        [Order(5)]
        public void DeleteMilestoneTest()
        {
            var actualMilestone = MilestoneServices!.DeleteMilestone(_milestone.ID.ToString());

            Assert.That(actualMilestone == HttpStatusCode.OK);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Assert.That(ProjectServices!.DeleteProject(_project.Id.ToString()) == HttpStatusCode.OK);
        }


    }

}
