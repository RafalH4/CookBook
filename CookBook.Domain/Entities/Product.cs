using CookBook.Domain.Common;

namespace CookBook.Domain.Entities
{
    public abstract class Product : CreatedByUserEntity
    {
        public string Name { get; set; }
        public double Energy { get; set; }
        public double Fat { get; set; }
        public double SaturatedFatInFat { get; set; }
        //Węglowodany, cukry
        public double Carbohydrates { get; set; }
        public double SugarsInCarbohydrates { get; set; }
        public double Protein { get; set; }
        public int Salt { get; set; }
        public User? User { get; set; }
        public Guid? UserId { get; set; }


        public string Description { get; set; }
        public ICollection<Ingredient> AsIngredient { get; set; }

    }
}
