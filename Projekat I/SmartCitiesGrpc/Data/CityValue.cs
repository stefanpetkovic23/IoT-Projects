using System.ComponentModel.DataAnnotations.Schema;
public class CityValue
{
    [Column("Id")]
    public int Id { get; set; }

    [Column("City")]
    public string City { get; set; }

    [Column("Country")]
    public string Country { get; set; }

    [Column("Smart_Mobility")]
    public float SmartMobility { get; set; }

    [Column("Smart_Environment")]
    public float SmartEnvironment { get; set; }

    [Column("Smart_Government")]
    public float SmartGovernment { get; set; }

    [Column("Smart_Economy")]
    public float SmartEconomy { get; set; }

    [Column("Smart_People")]
    public float SmartPeople { get; set; }

    [Column("Smart_Living")]
    public float SmartLiving { get; set; }

    [Column("SmartCity_Index")]
    public float SmartCityIndex { get; set; }

    [Column("SmartCity_Index_relative_Edmonton")]
    public float SmartCityIndexRelativeEdmonton { get; set; }
}
