using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.Data.Mocks
{
    public class MockFood : IAllFood
    {
        private readonly IAllCategory _category = new MockCategory();
        public IEnumerable<Food> Food
        {
            get
            {
                return new List<Food>
                {
                    new Food
                    {
                        Name = "Греческая",
                        Description = "Пицца «Греческая» 700 гр\r\nСоус красный, сыр моцарелла, помидоры, перец болгарский, лук маринованный, сыр Фета, маслины/оливки, орегано",
                        Price = 110,
                        Img = "/img/pizza/Grech.jpg",
                        Category = _category.AllCategory.First(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Пицца BBQ",
                        Description = "Вес 600 гр.\r\nСоус красный, Моцарелла, Невская, Охотничьи, Бекон, Лук, Соленые огурцы, Соус BBQ",
                        Price = 105,
                        Img = "/img/pizza/BBQ.png",
                        Category = _category.AllCategory.First(),
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Жюльен",
                        Description = "Вес 700 гр.\r\nСоус белый, Грибы свежие, Жюльен, Моцарелла.",
                        Price = 97,
                        Img = "/img/pizza/1.png.webp",
                        Category = _category.AllCategory.First(),
                        ToViewHome = false

                    },
                    new Food
                    {
                        Name = "Баварская",
                        Description = "Красный соус, сыр моцарелла, бекон, охотничьи колбаски, лук маринованный, перец чили.",
                        Price = 100,
                        Img = "/img/pizza/bavarskaya.png.webp",
                        Category = _category.AllCategory.First(),
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Пепперони",
                        Description = "Вес 650г\r\nКрасный соус, сыр моцарелла, колбаски солями, грибы, болгарский перец.",
                        Price = 115,
                        Img = "/img/pizza/peperoni-1.png.webp",
                        Category = _category.AllCategory.First(),
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Неаполитана",
                        Description = "Вес 690г\r\nКрасный соус, сыр моцарелла, ветчина, колбаски салями, помидоры, маслины/оливки.",
                        Price = 99,
                        Img = "/img/pizza/neapolitana.png",
                        Category = _category.AllCategory.First(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Карбонара",
                        Description = "Вес 720г\r\nБелый соус, сыр моцарелла, сыр пармезан, ветчина, бекон, соус карбонара.",
                        Price = 109,
                        Img = "/img/pizza/karbonara.png",
                        Category = _category.AllCategory.First(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Милано",
                        Description = "Вес 820г\r\nКрасный соус, сыр моцарелла, куриное филе в сливочном соусе, помидоры, грибы, болгарский перец, маслины/оливки.",
                        Price = 97,
                        Img = "/img/pizza/milano.png",
                        Category = _category.AllCategory.First(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Маргарита",
                        Description = "Вес 620г\r\nКрасный соус, сыр моцарелла, помидоры, маслины/оливки.",
                        Price = 55,
                        Img = "/img/pizza/margarita.png",
                        Category = _category.AllCategory.First(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "4 сыра",
                        Description = "Вес 590г\r\nбелый соус, сыр моцарелла, сыр пармезан, сыр радомер, сыр дорблю, маслины/оливки",
                        Price = 99,
                        Img = "/img/pizza/4-syra.png",
                        Category = _category.AllCategory.First(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Филадельфия классическая",
                        Description = "Вес 290 г\r\n\r\nРис, нори, сыр филадельфия, шапка лосося, огурец.",
                        Price = 99,
                        Img = "/img/Rolls/fila-klassik.png",
                        Category = _category.AllCategory.ElementAt(2),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Филадельфия Люкс",
                        Description = "Вес 310 гр\r\n\r\nНори, рис, сыр Филадельфия, снежный краб, шапки лосося.",
                        Price = 103,
                        Img = "/img/Rolls/PhilaLux.jpg",
                        Category = _category.AllCategory.ElementAt(2),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Калифорния",
                        Description = "Вес 270г\r\n\r\nРис, нори, сыр филадельфия, снежный краб, огурец, авокадо, игра тобико.",
                        Price = 110,
                        Img = "/img/Rolls/kaliforniya.png",
                        Category = _category.AllCategory.ElementAt(2),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Аляска",
                        Description = "Вес 280 гр.\r\n\r\nНори, рис, сыр филадельфия, икра красная, омлет, лосось, Кунжут/унаги.",
                        Price = 105,
                        Img = "/img/Rolls/alyaska.png",
                        Category = _category.AllCategory.ElementAt(2),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Аризона",
                        Description = "Вес 260 гр.\r\n\r\nНори, рис, сыр филадельфия, мидии в панко, угорь, огурец, шапки сыр/икра чёрная.",
                        Price = 90,
                        Img = "/img/Rolls/arizona.png",
                        Category = _category.AllCategory.ElementAt(2),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Курица по мексикански (острая)",
                        Description = "Куриное филе, Лук, Перец болгарский, Кукуруза, Помидор, Заправка: остро-сладкий, шрирача, терияки, соевый соуса.\r\n\r\nВес 350 гр.",
                        Price = 56,
                        Img = "/img/WOK/kurmek.jpg",
                        Category = _category.AllCategory.ElementAt(1),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Рис с овощами",
                        Description = "Рис, Перец болгарский, Стручковая фасоль, Брокколи, Кукуруза, Помидор, Заправка: остро-сладкий, соевый, терияки соуса.\r\n\r\nВес 350 гр.",
                        Price = 45,
                        Img = "/img/WOK/risovos.jpg",
                        Category = _category.AllCategory.ElementAt(1),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Лапша с курицей",
                        Description = "Лук репчатый, морковь, грибы, перец сладкий, курица, лапша. Обжаренное в растительном масле, соусом терияки, соевым соусом. Кунжут\r\n\r\nВес 320 гр.",
                        Price = 55,
                        Img = "/img/WOK/lapkur.jpg",
                        Category = _category.AllCategory.ElementAt(1),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Цезарь с курицей",
                        Description = "Вес 270 г\r\n\r\nЛатук, Помидор, Куриное филе, Соус цезарь, Сыр пармезан, Сухари Халла.",
                        Price = 73,
                        Img = "/img/salat/cezar.png",
                        Category = _category.AllCategory.ElementAt(3),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Салат Греческий",
                        Description = "Вес 300 г\r\n\r\nЛатук, Помидор, Огурец, Перец болгарский, Лук маринованный, Маслины, сыр Фета, Сок лимона, Масло растительное.",
                        Price = 65,
                        Img = "/img/salat/grec.png",
                        Category = _category.AllCategory.ElementAt(3),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Салат Авокадо",
                        Description = "Вес 300 г\r\n\r\nРуккола, Фета, Черри, Авокадо, Кунжутное масло, Кунжут, Сок лимона, Растительное масло.",
                        Price = 70,
                        Img = "/img/salat/avokado.png",
                        Category = _category.AllCategory.ElementAt(3),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Кола",
                        Description = "0.75л",
                        Price = 23,
                        Img = "/img/drink/coca.png",
                        Category = _category.AllCategory.Last(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Фанта",
                        Description = "0.75л",
                        Price = 23,
                        Img = "/img/drink/fanta.png",
                        Category = _category.AllCategory.Last(),
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Спрайт",
                        Description = "0.75л",
                        Price = 23,
                        Img = "/img/drink/sprite.png",
                        Category = _category.AllCategory.Last(),
                        ToViewHome = false
                    },
                };
            }
        }
        public IEnumerable<Food> GetViewFoods {  get; set; }
        public Food GetObjectFood(int foodId)
        {
            throw new System.NotImplementedException();
        }
    }
}
