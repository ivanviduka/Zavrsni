using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Runtime.Serialization;


namespace WebAPI.Controllers
{
    [DataContract]
    public class profesor {

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public string Prezime { get; set; }

        [DataMember]

        public string Kabinet { get; set; }

        public profesor(string ime, string prezime, string kabinet) {

            this.Ime = ime;
            this.Prezime = prezime;
            this.Kabinet = kabinet;
        }
    }

    [DataContract]
    public class stavka
    {

        [DataMember]
        public string Naziv { get; set; }

        [DataMember]
        public int ID_profesora { get; set; }

        public stavka(string naziv, int id_profesora)
        {

            this.Naziv = naziv;
            this.ID_profesora = id_profesora;
            
        }
    }


    //[Authorize]
    public class ValuesController : ApiController
    {   
        // GET api/values
        public List<profesor> Get()
        {
            MySqlConnection connection = WebApiConfig.conn();

            MySqlCommand query = connection.CreateCommand();

            query.CommandText = "SELECT ime, prezime, kabinet FROM profesori";

            var profesor = new List<profesor>();

            try
            {
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                throw exception;
            }



            MySqlDataReader fetch_query = query.ExecuteReader();


            while (fetch_query.Read())
            {
                profesor.Add(new profesor(fetch_query["ime"].ToString(), fetch_query["prezime"].ToString(), fetch_query["kabinet"].ToString()));
            }

            return profesor;

        }

        // GET api/values/5
        public List<profesor> Get(int id)
        {
            MySqlConnection connection = WebApiConfig.conn();

            MySqlCommand query = connection.CreateCommand();

            query.CommandText = "SELECT ime, prezime, kabinet FROM profesori, stavke_inventure WHERE profesori.id = stavke_inventure.id_profesora AND stavke_inventure.id = @id";

            query.Parameters.AddWithValue("@id", id);

            var profesor = new List<profesor>();

            try
            {
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                throw exception;
            }



            MySqlDataReader fetch_query = query.ExecuteReader();


            while (fetch_query.Read())
            {
                profesor.Add(new profesor(fetch_query["ime"].ToString(), fetch_query["prezime"].ToString(), fetch_query["kabinet"].ToString()));
            }

            return profesor;

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] stavka stavka)
        {
            MySqlConnection connection = WebApiConfig.conn();

            MySqlCommand query = connection.CreateCommand();

            query.CommandText = "INSERT INTO stavke_inventure (naziv, id_profesora) VALUES (@naziv, @id_profesora)";

            query.Parameters.AddWithValue("@naziv", stavka.Naziv);
            query.Parameters.AddWithValue("@id_profesora", stavka.ID_profesora);
            

            try
            {
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                throw exception;
            }

            
           

            try
            {
                MySqlDataReader fetch_query = query.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                throw exception;
            }

        }

      
    }
}
