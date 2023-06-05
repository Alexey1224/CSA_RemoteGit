namespace CSA.Storage
{
    public enum StorageEnum
    {
        Undefined,
        LaptopList,
        FileStorage
    }

    public static class StorageEnumExtensions
    {
        public static StorageEnum ToStorageEnum(this string value)
        {
            switch (value)
            {
                case var s when s.ToLowerInvariant() == "laptopList"
                                || s.ToLowerInvariant() == "Laptop"
                                || s.ToLowerInvariant() == "сonsolesList":
                    return StorageEnum.LaptopList;
                case var s when s.ToLowerInvariant() == "filestorage"
                                || s.ToLowerInvariant() == "file"
                                || s.ToLowerInvariant() == "storage":
                    return StorageEnum.FileStorage;
                default:
                    return StorageEnum.Undefined;
            }
        }
    }
}