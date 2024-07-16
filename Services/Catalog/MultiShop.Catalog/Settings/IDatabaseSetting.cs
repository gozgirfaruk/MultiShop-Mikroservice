namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSetting
    {
        public string CategoryCollection { get; set; }
        public string ProductCollection { get; set; }
        public string ProductImageCollection { get; set; }
        public string ProductPreviewCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
