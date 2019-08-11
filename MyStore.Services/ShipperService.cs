using System;
using System.Collections.Generic;
using System.Text;
using MyStore.Data;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;

namespace MyStore.Services
{
    public interface IShipperService
    {
        IEnumerable<Shippers> GetAllShippers();
        Shippers FindMyShipperById(int id);

        Shippers UpdateShipper(Shippers shipperToUpdate);

        Shippers AddShipper(Shippers addedShipper);

       
    }
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        public IEnumerable<Shippers> GetAllShippers()
        {
            return shipperRepository.GetAllShippers();
        }

        public Shippers FindMyShipperById(int id)
        {
            var myShipper = shipperRepository.GetShipperById(id);

            if (myShipper != null)
            {
                return myShipper;
            }

            return null;
        }

        public Shippers UpdateShipper(Shippers shipperToUpdate)
        {//id wverything ok, update the shipper in db

            return shipperRepository.Update(shipperToUpdate);
        }

        public Shippers AddShipper(Shippers addedShipper)
        {
            if (IsUniqueCompany(addedShipper.Companyname))
            {
                return shipperRepository.AddShipper(addedShipper);
            }
            return null;
        }

        private bool IsUniqueCompany(string name)
        {
            return shipperRepository.IsUniqueCompanyName(name);
        }
    }
}
