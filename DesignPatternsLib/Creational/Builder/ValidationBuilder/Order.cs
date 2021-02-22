using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.ValidationBuilder
{
    /* Just putting all the models here.
     * For an enterprise project, should create a Model folder that holds
     * all model classes. Each class should be its own file.
     */

    public class OrderWrapper
    {
        [JsonProperty("order")]
        public Order Order { get; set; }
    }

    public class Order
    {
        [JsonProperty("pet")]
        public Pet Pet { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("payment")]
        public Payment Payment { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }
    }

    public class Pet
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Breed")]
        public string Breed { get; set; }

        [JsonProperty("Sex")]
        public string Sex { get; set; }
    }

    public class User
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }
    }

    public class Payment
    {
        [JsonProperty("CC")]
        public string CC { get; set; }

        [JsonProperty("BillingAddress")]
        public string Email { get; set; }
    }

    public class Product
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }
    }

    public class Service
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }
    }
}
