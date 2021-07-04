using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class PersonProcessor
    {
        public static int CreatePerson(string FirstName, string LastName, string Address,
            long PartnerNumber, long CroatianPIN, int PartnerTypeId, DateTime CreatedAtUtc, string CreateByUser,
            bool IsForeign, string ExternalCode, char Gender)
        {
            PersonModel data = new PersonModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                PartnerNumber = PartnerNumber,
                CroatianPIN = CroatianPIN,
                PartnerTypeId = PartnerTypeId,
                CreatedAtUtc = CreatedAtUtc,
                CreateByUser = CreateByUser,
                IsForeign = IsForeign,
                ExternalCode = ExternalCode,
                Gender = Gender
            };

            string sql = @"insert into dbo.Person (FirstName, LastName, Address, PartnerNumber,
                        CroatianPIN, PartnerTypeId, CreatedAtUtc, CreateByUser, IsForeign, ExternalCode, Gender)
                        values (@FirstName, @LastName, @Address, @PartnerNumber,
                        @CroatianPIN, @PartnerTypeId, @CreatedAtUtc, @CreateByUser, @IsForeign, @ExternalCode, @Gender);";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<PersonModel> LoadPersons()
        {
            string sql = @"select Id, FirstName, LastName, Address, PartnerNumber,
                        CroatianPIN, PartnerTypeId, CreatedAtUtc, CreateByUser, IsForeign, ExternalCode, Gender
                        from dbo.Person;";

            return SQLDataAccess.LoadData<PersonModel>(sql);
        }
    }
}
