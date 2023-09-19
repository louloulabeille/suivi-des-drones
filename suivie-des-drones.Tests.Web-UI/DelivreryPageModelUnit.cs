using Microsoft.Extensions.Logging;
using Moq;
using NuGet.Protocol.Core.Types;
using suivi_des_drones.Core.Models;
using suivi_des_drones.Pages;
using suivie_des_drones.Core.Application.Repository;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;
using suivie_des_drones.Tests.Web_UI.Fakes;

namespace suivie_des_drones.Tests.Web_UI
{
    public class DelivreryPageModelUnit
    {
        [Fact]
        public void ShouldListTwoDelivreries()
        {
            ILogger<DelivreryListModel> logger = null;
            //IRepositoryDelivrery repository = new FakeDelivreryRepository(); ne pas mock le repository ou le workofunit
            // mais le Layer ou le repository (accés à la base de données)

            /*var moqRepo = new Mock<IRepositoryDelivrery>();
            moqRepo.Setup(item => item.GetAll()).Returns(new List<Delivrery>() {
                new Delivrery(),
                new Delivrery(),
            });*/

            var moqLayer = new Mock<IDelivreryDataLayer>();
            moqLayer.Setup(item => item.GetAll()).Returns(new List<Delivrery>() {
                new Delivrery(),
                new Delivrery(),
            });

            IRepositoryDelivrery repository = new DelivreryRepository(moqLayer.Object);

            //moqRepo.VerifyAll(); // vérifie s'il a bien été appelé 

            DelivreryListModel delivreryPage = new(logger, repository);
            //DelivreryListModel delivreryPage = new(logger, moqRepo.Object);


            var result = delivreryPage.OnGet();
            var list = delivreryPage.Delivreries;

            moqLayer.VerifyAll(); // vérifie s'il a bien utilisé
            Assert.NotNull(result); // test si la page existe
            Assert.IsType < List < Delivrery >> (list);
            Assert.NotNull (list);
            Assert.True(list.Count > 0);

        }
    }
}