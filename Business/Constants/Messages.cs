using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added";
        public static string ProductNameInvalid = "Product Name is invalid";
        public static string MaintenanceTime = "System in maintenance";
        public static string ProductListed= "Products listed";
        public static string ProductCountOfCategory = "There can be a maximum of 10 products from the same category.";
        public static string ProductNameAlreadyExists = "Cannot have product name in the same name.";
        public static string CategoryLimitExciteded = "If the current number of categories exceeds 15, new products cannot be added to the system.";
    }
}
