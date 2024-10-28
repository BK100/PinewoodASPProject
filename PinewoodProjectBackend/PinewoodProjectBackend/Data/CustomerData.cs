using PinewoodProjectBackend.Models;
using PinewoodProjectBackend.Models.Enums;

namespace PinewoodProjectBackend.Data
{
    // Customer profile data repo. Ideally this would be implemented through a database and interacted with using stored procedures

    public static class CustomerData
    {
        // Data stored in dictionary for faster hash lookup
        private static Dictionary<int, CustomerProfile> ProfileList = new Dictionary<int, CustomerProfile> {
            {1,  new CustomerProfile{ CustomerID = 1, DateRegistered = DateOnly.Parse("2024-10-28"), ProductType = ProductType.Business, EnableMarketing = true} },
            {2, new CustomerProfile{ CustomerID = 2, DateRegistered = DateOnly.Parse("2023-09-01"), ProductType = ProductType.Insurance, EnableMarketing = false} },
            {3, new CustomerProfile{ CustomerID = 3, DateRegistered = DateOnly.Parse("2024-10-05"), ProductType = ProductType.Commercial, EnableMarketing = true} },
            {4, new CustomerProfile{ CustomerID = 4, DateRegistered = DateOnly.Parse("2024-11-28"), ProductType = ProductType.Business, EnableMarketing = true} },
            {5, new CustomerProfile{ CustomerID = 5, DateRegistered = DateOnly.Parse("2022-03-12"), ProductType = ProductType.Business, EnableMarketing = false} },
            {6, new CustomerProfile{ CustomerID = 6, DateRegistered = DateOnly.Parse("2022-02-20"), ProductType = ProductType.Miscellaneous, EnableMarketing = true}},
            {7, new CustomerProfile{ CustomerID = 7, DateRegistered = DateOnly.Parse("2024-10-13"), ProductType = ProductType.Insurance, EnableMarketing = false}},
            {8, new CustomerProfile{ CustomerID = 8, DateRegistered = DateOnly.Parse("2023-11-03"), ProductType = ProductType.Commercial, EnableMarketing = false}},
            {9, new CustomerProfile{ CustomerID = 9, DateRegistered = DateOnly.Parse("2020-04-12"), ProductType = ProductType.Business, EnableMarketing = true}},
            {10, new CustomerProfile{ CustomerID = 10, DateRegistered = DateOnly.Parse("2021-07-08"), ProductType = ProductType.Commercial, EnableMarketing = false}}};

        public static List<CustomerProfile> GetList()
        {
            return ProfileList.Values.ToList();
        }

        public static void DeleteRecord(int id)
        {
            ProfileList.Remove(id);
        }

        public static void AddRecord(CustomerProfile profile)
        {
            ProfileList.Add(profile.CustomerID, profile);
        }

        public static void UpdateRecord(CustomerProfile profile)
        {
            try
            {
                // Defaults to customerID if originalID is missing for whatever reason
                var idToUpdate = profile.OriginalID.HasValue ? profile.OriginalID.Value : profile.CustomerID;

                // Clears the originalID reference before updating so it isn't stored
                profile.OriginalID = null;
                if (idToUpdate == profile.CustomerID)
                {
                    ProfileList.Remove(idToUpdate);
                    ProfileList.Add(profile.CustomerID, profile);
                }
                else
                {
                    ProfileList.Add(profile.CustomerID, profile);
                    ProfileList.Remove(idToUpdate);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PP004: Could not find the specified record to update", ex);
            }
        }
    }
}
