
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CinemaNetworkApp.DataFolder
{

using System;
    using System.Collections.Generic;
    
public partial class CinemaPlace
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public CinemaPlace()
    {

        this.Cinema = new HashSet<Cinema>();

        this.Country = new HashSet<Country>();

    }


    public int IdCinemaPlace { get; set; }

    public int IdMetro { get; set; }

    public string ShoppingCenter { get; set; }

    public int IdCity { get; set; }

    public int HouseNumber { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Cinema> Cinema { get; set; }

    public virtual City City { get; set; }

    public virtual Metro Metro { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Country> Country { get; set; }

}

}
