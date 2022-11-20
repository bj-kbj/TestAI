using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }
        public DbSet<Books> MyUser { get; set; }
    }

    //public class DataSettingsManager
    //{
    //    private const string _dataSettingsFilePath = "App_Data/dataSettings.json";
    //    public virtual DataSettings LoadSettings()
    //    {
    //        var text = File.ReadAllText(_dataSettingsFilePath);
    //        if (string.IsNullOrEmpty(text))
    //            return new DataSettings();

    //        //get data settings from the JSON file  
    //        DataSettings settings = JsonConvert.DeserializeObject<DataSettings>(text);
    //        return settings;
    //    }

    //}

    //public class DataSettings
    //{
    //    public string DataConnectionString { get; set; }
    //}
}
