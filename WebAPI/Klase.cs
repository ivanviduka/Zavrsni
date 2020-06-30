using System;

public class stavka
{


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



    public stavka(string oznaka, string id_osobe, string aai, string ime_osobe, string naziv, string kolicina, string popisna_jedinica, string mjesto_id, string mjesto_troska,
        string sadasnja_vrijednost, string napomena, string izvan_zgrade, string prijedlog_za_otpis, string privatna_imovina, string otpala_naljepnica, string inicijalno_stanje,
        int datum_ispisa, int datum_izmjene, string izmijenio, string unio, string obrisano)
    {

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
