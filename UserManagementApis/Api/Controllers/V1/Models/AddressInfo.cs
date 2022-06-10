namespace UserManagementApi.Api.Controllers.V1.Models
{
    public class AddressInfo
    {
        /// <summary>
        /// Street Name
        /// </summary>
        public string? Street { get; set; }
        /// <summary>
        /// Suite
        /// </summary>
        public string? Suite { get; set; }
        /// <summary>
        /// Name of the City
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// Area ZipCode
        /// </summary>
        public string? ZipCode { get; set; }
        /// <summary>
        /// Geological Location
        /// </summary>
        public GeoInfo Geo { get; set; } = new GeoInfo();
    }
}
