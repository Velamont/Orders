using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Orders.Data.Model.Enums
{
	public enum Status
	{
		[Display(Name = "Зарегистрирован")]
		[EnumMember(Value = "Зарегистрирован")]
		Registered,
		[Display(Name = "Принят на складе")]
		[EnumMember(Value = "Принят на складе")]
		AcceptedInStock,
		[Display(Name = "Выдан курьеру")]
		[EnumMember(Value = "Выдан курьеру")]
		IssuedToCourier,
		[Display(Name = "Доставлен в постамат")]
		[EnumMember(Value = "Доставлен в постамат")]
		ArrivedToPostamate,
		[Display(Name = "Доставлен получателю")]
		[EnumMember(Value = "Доставлен получателю")]
		DeliveredToRecipient
	}
}
