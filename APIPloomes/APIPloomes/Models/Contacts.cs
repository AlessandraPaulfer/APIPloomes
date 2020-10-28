using APIPloomes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIPloomes
{
    public class Contacts
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public object LegalName { get; set; }
        public object Register { get; set; }
        public object CNPJ { get; set; }
        public object CPF { get; set; }
        public int StatusId { get; set; }
        public object CompanyId { get; set; }
        public object RelationshipId { get; set; }
        public object LineOfBusinessId { get; set; }
        public object OriginId { get; set; }
        public object NumberOfEmployeesId { get; set; }
        public int ClassId { get; set; }
        public object OwnerId { get; set; }
        public object Birthday { get; set; }
        public object NextAnniversary { get; set; }
        public object PreviousAnniversary { get; set; }
        public object Note { get; set; }
        public object Email { get; set; }
        public object Website { get; set; }
        public object RoleId { get; set; }
        public object DepartmentId { get; set; }
        public object Skype { get; set; }
        public object Facebook { get; set; }
        public object StreetAddress { get; set; }
        public object StreetAddressNumber { get; set; }
        public object StreetAddressLine2 { get; set; }
        public object Neighborhood { get; set; }
        public object ZipCode { get; set; }
        public object CityId { get; set; }
        public object StateId { get; set; }
        public object CountryId { get; set; }
        public object CurrencyId { get; set; }
        public object EmailMarketing { get; set; }
        public object CNAECode { get; set; }
        public object CNAEName { get; set; }
        public object Latitude { get; set; }
        public object Longitude { get; set; }
        public object ImportId { get; set; }
        public object CreateImportationId { get; set; }
        public object UpdateImportationId { get; set; }
        public object FirstTaskId { get; set; }
        public object FirstTaskDate { get; set; }
        public int LastInteractionRecordId { get; set; }
        public int LastDealId { get; set; }
        public int LastOrderId { get; set; }
        public int TasksOrdination { get; set; }
        public object LeadId { get; set; }
        public bool Editable { get; set; }
        public bool Deletable { get; set; }
        public int CreatorId { get; set; }
        public object UpdaterId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public object Key { get; set; }
        public object LastDocumentId { get; set; }
        public object AvatarUrl { get; set; }
        public object HasConsent { get; set; }
    }

    public class Root
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Contacts> value { get; set; }
    }

}
