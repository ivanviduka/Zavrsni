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
    public class stavka {

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Oznaka { get; set; }

        [DataMember]
        public string ID_osobe { get; set; }

        [DataMember]
        public string AAI { get; set; }

        [DataMember]
        public string Ime_osobe { get; set; }

        [DataMember]
        public string Naziv { get; set; }

        [DataMember]
        public string Kolicina { get; set; }

        [DataMember]
        public string Popisna_jedinica { get; set; }

        [DataMember]
        public string Mjesto_id { get; set; }

        [DataMember]
        public string Mjesto_troska { get; set; }

        [DataMember]
        public string Sadasnja_vrijednost { get; set; }

        [DataMember]
        public string Napomena { get; set; }

        [DataMember]
        public string Izvan_zgrade { get; set; }

        [DataMember]
        public string Prijedlog_za_otpis { get; set; }

        [DataMember]
        public string Privatna_imovina { get; set; }

        [DataMember]
        public string Otpala_naljepnica { get; set; }

        [DataMember]
        public string Inicijalno_stanje { get; set; }

        [DataMember]
        public int Datum_ispisa { get; set; }

        [DataMember]
        public int Datum_izmjene { get; set; }

        [DataMember]
        public string Izmijenio { get; set; }

        [DataMember]
        public string Unio { get; set; }

        [DataMember]
        public string Obrisano { get; set; }



        public stavka(int ID, string oznaka, string id_osobe, string aai, string ime_osobe, string naziv, string kolicina, string popisna_jedinica, string mjesto_id, string mjesto_troska,
            string sadasnja_vrijednost, string napomena, string izvan_zgrade, string prijedlog_za_otpis, string privatna_imovina, string otpala_naljepnica, string inicijalno_stanje,
            int datum_ispisa, int datum_izmjene, string izmijenio, string unio, string obrisano) {

            this.ID = ID;
            this.Oznaka = oznaka;
            this.ID_osobe = id_osobe;
            this.AAI = aai;
            this.Ime_osobe = ime_osobe;
            this.Naziv = naziv;
            this.Kolicina = kolicina;
            this.Popisna_jedinica = popisna_jedinica;
            this.Mjesto_id = mjesto_id;
            this.Mjesto_troska = mjesto_troska;
            this.Sadasnja_vrijednost = sadasnja_vrijednost;
            this.Napomena = napomena;
            this.Izvan_zgrade = izvan_zgrade;
            this.Prijedlog_za_otpis = prijedlog_za_otpis;
            this.Privatna_imovina = privatna_imovina;
            this.Otpala_naljepnica = otpala_naljepnica;
            this.Inicijalno_stanje = inicijalno_stanje;
            this.Datum_ispisa = datum_ispisa;
            this.Datum_izmjene = datum_izmjene;
            this.Izmijenio = izmijenio;
            this.Unio = unio;
            this.Obrisano = obrisano;
    }

    }

    [DataContract]
    public class prostorija
    {

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Popisna_jedinica { get; set; }

        public prostorija(int ID, string popisna_jedinica)
        {
            this.ID = ID;
            this.Popisna_jedinica = popisna_jedinica;
            
        }
    }


    

    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {   
        // GET api/values
        public List<stavka> Get()
        {
            MySqlConnection connection = WebApiConfig.conn();

            MySqlCommand query = connection.CreateCommand();

            

            query.CommandText = "SELECT * FROM einventura_stavke";

            var stavka = new List<stavka>();

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
                stavka.Add(new stavka(int.Parse( fetch_query["id"].ToString()), fetch_query["oznaka"].ToString(), fetch_query["id_osobe"].ToString(), fetch_query["aai"].ToString(), 
                                       fetch_query["ime_osobe"].ToString(), fetch_query["naziv"].ToString(), fetch_query["kolicina"].ToString(), fetch_query["popisna_jedinica"].ToString(),
                                       fetch_query["mjesto_id"].ToString(), fetch_query["mjesto_troska"].ToString(), fetch_query["sadasnja_vrijednost"].ToString(), fetch_query["napomena"].ToString(),
                                       fetch_query["izvan_zgrade"].ToString(), fetch_query["prijedlog_za_otpis"].ToString(), fetch_query["privatna_imovina"].ToString(),
                                       fetch_query["otpala_naljepnica"].ToString(), fetch_query["inicijalno_stanje"].ToString(), int.Parse(fetch_query["datum_ispisa"].ToString()),
                                       int.Parse(fetch_query["datum_izmjene"].ToString()), fetch_query["izmijenio"].ToString(), fetch_query["unio"].ToString(),fetch_query["obrisano"].ToString()));
            }

            return stavka;

        }


        // GET api/values/5
        [Route("{id:int}")]
        public List<stavka> Get(int id)
        {
            MySqlConnection connection = WebApiConfig.conn();

            MySqlCommand query = connection.CreateCommand();

            query.CommandText = "SELECT * FROM einventura_stavke, einventura_prostorije " +
                                "WHERE einventura_stavke.popisna_jedinica = einventura_prostorije.popisna_jedinica AND einventura_stavke.id = @id";

            query.Parameters.AddWithValue("@id", id);

            var stavka = new List<stavka>();

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
                stavka.Add(new stavka(int.Parse(fetch_query["id"].ToString()), fetch_query["oznaka"].ToString(), fetch_query["id_osobe"].ToString(), fetch_query["aai"].ToString(),
                                       fetch_query["ime_osobe"].ToString(), fetch_query["naziv"].ToString(), fetch_query["kolicina"].ToString(), fetch_query["popisna_jedinica"].ToString(),
                                       fetch_query["mjesto_id"].ToString(), fetch_query["mjesto_troska"].ToString(), fetch_query["sadasnja_vrijednost"].ToString(), fetch_query["napomena"].ToString(),
                                       fetch_query["izvan_zgrade"].ToString(), fetch_query["prijedlog_za_otpis"].ToString(), fetch_query["privatna_imovina"].ToString(),
                                       fetch_query["otpala_naljepnica"].ToString(), fetch_query["inicijalno_stanje"].ToString(), int.Parse(fetch_query["datum_ispisa"].ToString()),
                                       int.Parse(fetch_query["datum_izmjene"].ToString()), fetch_query["izmijenio"].ToString(), fetch_query["unio"].ToString(), fetch_query["obrisano"].ToString()));
            }

            return stavka;

        }

        // GET api/values/0-10
        [Route("{prostorija}")]
        public List<stavka> Get(string prostorija)
        {
            MySqlConnection connection = WebApiConfig.conn();

            MySqlCommand query = connection.CreateCommand();

            query.CommandText = "SELECT * FROM einventura_stavke WHERE popisna_jedinica = @prostorija";

            query.Parameters.AddWithValue("@prostorija", prostorija);

            var stavka = new List<stavka>();

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
                stavka.Add(new stavka(int.Parse(fetch_query["id"].ToString()), fetch_query["oznaka"].ToString(), fetch_query["id_osobe"].ToString(), fetch_query["aai"].ToString(),
                                       fetch_query["ime_osobe"].ToString(), fetch_query["naziv"].ToString(), fetch_query["kolicina"].ToString(), fetch_query["popisna_jedinica"].ToString(),
                                       fetch_query["mjesto_id"].ToString(), fetch_query["mjesto_troska"].ToString(), fetch_query["sadasnja_vrijednost"].ToString(), fetch_query["napomena"].ToString(),
                                       fetch_query["izvan_zgrade"].ToString(), fetch_query["prijedlog_za_otpis"].ToString(), fetch_query["privatna_imovina"].ToString(),
                                       fetch_query["otpala_naljepnica"].ToString(), fetch_query["inicijalno_stanje"].ToString(), int.Parse(fetch_query["datum_ispisa"].ToString()),
                                       int.Parse(fetch_query["datum_izmjene"].ToString()), fetch_query["izmijenio"].ToString(), fetch_query["unio"].ToString(), fetch_query["obrisano"].ToString()));
            }

            return stavka;

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] stavka stavka)
        {
            MySqlConnection connection = WebApiConfig.conn();

            MySqlCommand query = connection.CreateCommand();

            query.CommandText = "INSERT INTO einventura_stavke (id, oznaka, id_osobe, aai, ime_osobe, naziv, kolicina, popisna_jedinica, mjesto_id, mjesto_troska, "+
                                 "sadasnja_vrijednost, napomena, izvan_zgrade, prijedlog_za_otpis, privatna_imovina, otpala_naljepnica, inicijalno_stanje, " +
                                 "datum_ispisa, datum_izmjene, izmijenio, unio, obrisano) "+ 
                                "VALUES (@id, @oznaka, @id_osobe, @aai, @ime_osobe, @naziv, @kolicina, @popisna_jedinica, @mjesto_id, "+
                                "@mjesto_troska, @sadasnja_vrijednost, @napomena, @izvan_zgrade, @prijedlog_za_otpis, @privatna_imovina, @otpala_naljepnica, "+
                                "@inicijalno_stanje, @datum_ispisa, @datum_izmjene, @izmijenio, @unio, @obrisano)";

            query.Parameters.AddWithValue("@id", stavka.ID);
            query.Parameters.AddWithValue("@oznaka", stavka.Oznaka);
            query.Parameters.AddWithValue("@id_osobe", stavka.ID_osobe);
            query.Parameters.AddWithValue("@aai", stavka.AAI);
            query.Parameters.AddWithValue("@ime_osobe", stavka.Ime_osobe);
            query.Parameters.AddWithValue("@naziv", stavka.Naziv);
            query.Parameters.AddWithValue("@kolicina", stavka.Kolicina);
            query.Parameters.AddWithValue("@popisna_jedinica", stavka.Popisna_jedinica);
            query.Parameters.AddWithValue("@mjesto_id", stavka.Mjesto_id);
            query.Parameters.AddWithValue("@mjesto_troska", stavka.Mjesto_troska);
            query.Parameters.AddWithValue("@sadasnja_vrijednost", stavka.Sadasnja_vrijednost);
            query.Parameters.AddWithValue("@napomena", stavka.Napomena);
            query.Parameters.AddWithValue("@izvan_zgrade", stavka.Izvan_zgrade);
            query.Parameters.AddWithValue("@prijedlog_za_otpis", stavka.Prijedlog_za_otpis);
            query.Parameters.AddWithValue("@privatna_imovina", stavka.Privatna_imovina);
            query.Parameters.AddWithValue("@otpala_naljepnica", stavka.Otpala_naljepnica);
            query.Parameters.AddWithValue("@inicijalno_stanje", stavka.Inicijalno_stanje);
            query.Parameters.AddWithValue("@datum_ispisa", stavka.Datum_ispisa);
            query.Parameters.AddWithValue("@datum_izmjene", stavka.Datum_izmjene);
            query.Parameters.AddWithValue("@izmijenio", stavka.Izmijenio);
            query.Parameters.AddWithValue("@unio", stavka.Unio);
            query.Parameters.AddWithValue("@obrisano", stavka.Obrisano);


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
