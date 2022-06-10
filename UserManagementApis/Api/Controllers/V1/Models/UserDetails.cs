using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementApi.Api.Controllers.V1.Models
{
    public class UserDetails
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UId { get; set; }
        /// <summary>
        /// User Identifiaction
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the user
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Account Name
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// Email Address of the user
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Address of the user
        /// </summary>
        public AddressInfo Address { get; set; } = new AddressInfo();
        /// <summary>
        /// Phone number of the user
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Website Name
        /// </summary>
        public string? Website { get; set; }
        /// <summary>
        /// Company Information
        /// </summary>
        public CompanyInfo Company { get; set; } = new CompanyInfo();
    }
}

