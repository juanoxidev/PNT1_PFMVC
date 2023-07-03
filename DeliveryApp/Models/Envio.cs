using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public enum Envio
    {
        [Display(Name = "Retiro en local")]
        RETIRO_EN_LOCAL,
        [Display(Name = "Envio a domicilio")]
        ENVIO_A_DOMICILIO,
        [Display(Name = "Consumo en local")]
        CONSUMO_EN_LOCAL,
    }
}
