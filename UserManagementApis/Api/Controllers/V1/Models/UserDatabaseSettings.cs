namespace UserManagementApi.Api.Controllers.V1.Models
{
    public class UserDatabaseSettings
    {
        /// <summary>
        /// DB connection string
        /// </summary>
        public string? ConnectionString { get; set; } = null;
        /// <summary>
        /// DB name
        /// </summary>
        public string? DatabaseName { get; set; } = null;
        /// <summary>
        /// DB collection name
        /// </summary>
        public string? UserCollectionName { get; set; } = null;
    }
}
