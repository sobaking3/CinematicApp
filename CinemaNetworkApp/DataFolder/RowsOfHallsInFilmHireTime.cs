
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
    
public partial class RowsOfHallsInFilmHireTime
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public RowsOfHallsInFilmHireTime()
    {

        this.PlacesInRownOFHallsInFilmHireTime = new HashSet<PlacesInRownOFHallsInFilmHireTime>();

    }


    public int IdFilmsHireTime { get; set; }

    public int RowNumber { get; set; }

    public decimal Cost { get; set; }

    public int IdRownFilmsHireTime { get; set; }



    public virtual FilmHireTime FilmHireTime { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PlacesInRownOFHallsInFilmHireTime> PlacesInRownOFHallsInFilmHireTime { get; set; }

}

}