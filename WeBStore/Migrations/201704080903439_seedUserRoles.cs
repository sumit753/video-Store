namespace WeBStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class seedUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0bd93a32-85bd-4550-8cdb-cbc5d899c558', N'sumit753@gmail.com', 0, N'AGy3dSgoWn9iBzw1XvkK5KOahjfNlYIFcZpJLCXnLDQgU6o7kzKqJqU9acT0Di2Tjw==', N'91780d0f-fff9-4b74-b39f-be0b9b61d93d', NULL, 0, 0, NULL, 1, 0, N'sumit753@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b9019676-0cfd-454a-b3ba-5ce9143fd784', N'user@gmail.com', 0, N'AC/7hwgI9uVvH828CSk0/OWpcQBakUnyk6gqolZv+TJo5WAoqfFVnVvGj3fuO5KHWQ==', N'73b243a7-d701-4d19-acb4-88be04552618', NULL, 0, 0, NULL, 1, 0, N'user@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc2fce7b-c04a-4d27-af82-f2cf46076d5c', N'admin@gmail.com', 0, N'AMEBb96spdZcQXnlmToG2Ip5bLrwzR8hpWeSGzw0w3yUfYDHi8Re9rQ13U7ZTEn2uA==', N'a2d4d93a-b0c5-4295-9d45-9378dd9fb3d1', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'274586d9-3cfd-4700-8967-94f118367433', N'CanManageMovies')
                ");
        }

        public override void Down()
        {
        }
    }
}
