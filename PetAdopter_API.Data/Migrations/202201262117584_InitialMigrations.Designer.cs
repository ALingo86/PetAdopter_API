﻿
namespace PetAdopter_API.Data.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class InitialMigrations : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(InitialMigrations));
        
        string IMigrationMetadata.Id
        {
<<<<<<<< HEAD:PetAdopter_API.Data/Migrations/202201262120377_INIT.Designer.cs
            get { return "202201262120377_INIT"; }

            get { return "202201262117584_InitialMigrations"; }
>>>>>>>> a92c894a64547578db76af93c2fd9ebcafec2cba:PetAdopter_API.Data/Migrations/202201262117584_InitialMigrations.Designer.cs
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
