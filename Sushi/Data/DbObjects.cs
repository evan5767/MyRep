using Sushi.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.Data
{
    public class DbObjects
    {
        public static void Initial(appDBContent content)
        {
            if (!content.Category.Any()) //Проверяем, нет ли уже категорий и, если их нет, добавляем их!
            {
                content.Category.AddRange(Categories.Select(c => c.Value));// из категорий берем объекты и присваиваем им значения ка отдельным объектам
            }

            //остается добавить все необходимые объекты товаров
            if (!content.Food.Any())
            {
                content.AddRange(
                    new Food
                    {
                        Name = "Греческая",
                        Description = "Пицца «Греческая» 700 гр\r\nСоус красный, сыр моцарелла, помидоры, перец болгарский, лук маринованный, сыр Фета, маслины/оливки, орегано",
                        Price = 110,
                        Img = "/img/pizza/Grech.jpg",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Пицца BBQ",
                        Description = "Вес 600 гр.\r\nСоус красный, Моцарелла, Невская, Охотничьи, Бекон, Лук, Соленые огурцы, Соус BBQ",
                        Price = 105,
                        Img = "/img/pizza/BBQ.png",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Жюльен",
                        Description = "Вес 700 гр.\r\nСоус белый, Грибы свежие, Жюльен, Моцарелла.",
                        Price = 97,
                        Img = "/img/pizza/1.png.webp",
                        Category = Categories["Пицца"],
                        ToViewHome = false

                    },
                    new Food
                    {
                        Name = "Баварская",
                        Description = "Красный соус, сыр моцарелла, бекон, охотничьи колбаски, лук маринованный, перец чили.",
                        Price = 100,
                        Img = "/img/pizza/bavarskaya.png.webp",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Пепперони",
                        Description = "Вес 650г\r\nКрасный соус, сыр моцарелла, колбаски солями, грибы, болгарский перец.",
                        Price = 115,
                        Img = "/img/pizza/peperoni-1.png.webp",
                        Category = Categories["Пицца"],
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Неаполитана",
                        Description = "Вес 690г\r\nКрасный соус, сыр моцарелла, ветчина, колбаски салями, помидоры, маслины/оливки.",
                        Price = 99,
                        Img = "/img/pizza/neapolitana.png",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Карбонара",
                        Description = "Вес 720г\r\nБелый соус, сыр моцарелла, сыр пармезан, ветчина, бекон, соус карбонара.",
                        Price = 109,
                        Img = "/img/pizza/karbonara.png",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Милано",
                        Description = "Вес 820г\r\nКрасный соус, сыр моцарелла, куриное филе в сливочном соусе, помидоры, грибы, болгарский перец, маслины/оливки.",
                        Price = 97,
                        Img = "/img/pizza/milano.png",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Маргарита",
                        Description = "Вес 620г\r\nКрасный соус, сыр моцарелла, помидоры, маслины/оливки.",
                        Price = 55,
                        Img = "/img/pizza/margarita.png",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "4 сыра",
                        Description = "Вес 590г\r\nбелый соус, сыр моцарелла, сыр пармезан, сыр радомер, сыр дорблю, маслины/оливки",
                        Price = 99,
                        Img = "/img/pizza/4-syra.png",
                        Category = Categories["Пицца"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Филадельфия классическая",
                        Description = "Вес 290 г\r\n\r\nРис, нори, сыр филадельфия, шапка лосося, огурец.",
                        Price = 99,
                        Img = "/img/Rolls/fila-klassik.png",
                        Category = Categories["Роллы"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Филадельфия Люкс",
                        Description = "Вес 310 гр\r\n\r\nНори, рис, сыр Филадельфия, снежный краб, шапки лосося.",
                        Price = 103,
                        Img = "/img/Rolls/PhilaLux.jpg",
                        Category = Categories["Роллы"],
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Ролл Калифорния",
                        Description = "Вес 270г\r\n\r\nРис, нори, сыр филадельфия, снежный краб, огурец, авокадо, игра тобико.",
                        Price = 110,
                        Img = "/img/Rolls/kaliforniya.png",
                        Category = Categories["Роллы"],
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Ролл Аляска",
                        Description = "Вес 280 гр.\r\n\r\nНори, рис, сыр филадельфия, икра красная, омлет, лосось, Кунжут/унаги.",
                        Price = 105,
                        Img = "/img/Rolls/alyaska.png",
                        Category = Categories["Роллы"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Ролл Аризона",
                        Description = "Вес 260 гр.\r\n\r\nНори, рис, сыр филадельфия, мидии в панко, угорь, огурец, шапки сыр/икра чёрная.",
                        Price = 90,
                        Img = "/img/Rolls/arizona.png",
                        Category = Categories["Роллы"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Курица по мексикански (острая)",
                        Description = "Куриное филе, Лук, Перец болгарский, Кукуруза, Помидор, Заправка: остро-сладкий, шрирача, терияки, соевый соуса.\r\n\r\nВес 350 гр.",
                        Price = 56,
                        Img = "/img/WOK/kurmek.jpg",
                        Category = Categories["WOK"],
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Рис с овощами",
                        Description = "Рис, Перец болгарский, Стручковая фасоль, Брокколи, Кукуруза, Помидор, Заправка: остро-сладкий, соевый, терияки соуса.\r\n\r\nВес 350 гр.",
                        Price = 45,
                        Img = "/img/WOK/risovos.jpg",
                        Category = Categories["WOK"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Лапша с курицей",
                        Description = "Лук репчатый, морковь, грибы, перец сладкий, курица, лапша. Обжаренное в растительном масле, соусом терияки, соевым соусом. Кунжут\r\n\r\nВес 320 гр.",
                        Price = 55,
                        Img = "/img/WOK/lapkur.jpg",
                        Category = Categories["WOK"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Цезарь с курицей",
                        Description = "Вес 270 г\r\n\r\nЛатук, Помидор, Куриное филе, Соус цезарь, Сыр пармезан, Сухари Халла.",
                        Price = 73,
                        Img = "/img/salat/cezar.png",
                        Category = Categories["Салаты"],
                        ToViewHome = true
                    },
                    new Food
                    {
                        Name = "Салат Греческий",
                        Description = "Вес 300 г\r\n\r\nЛатук, Помидор, Огурец, Перец болгарский, Лук маринованный, Маслины, сыр Фета, Сок лимона, Масло растительное.",
                        Price = 65,
                        Img = "/img/salat/grec.png",
                        Category = Categories["Салаты"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Салат Авокадо",
                        Description = "Вес 300 г\r\n\r\nРуккола, Фета, Черри, Авокадо, Кунжутное масло, Кунжут, Сок лимона, Растительное масло.",
                        Price = 70,
                        Img = "/img/salat/avokado.png",
                        Category = Categories["Салаты"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Кола",
                        Description = "0.75л",
                        Price = 23,
                        Img = "/img/drink/coca.png",
                        Category = Categories["Напитки"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Фанта",
                        Description = "0.75л",
                        Price = 23,
                        Img = "/img/drink/fanta.png",
                        Category = Categories["Напитки"],
                        ToViewHome = false
                    },
                    new Food
                    {
                        Name = "Спрайт",
                        Description = "0.75л",
                        Price = 23,
                        Img = "/img/drink/sprite.png",
                        Category = Categories["Напитки"],
                        ToViewHome = false
                    }
                    );
            }

            content.SaveChanges(); 
        }


        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{Name = "Пицца", Description = "Классическая итальянская пицца"},
                    new Category{Name = "WOK", Description = "Восточная еда, приготовленная на сковороде WOK"},
                    new Category{Name = "Роллы", Description = "Японская кухня"},
                    new Category{Name = "Салаты", Description = "Освежающие салаты"},
                    new Category{Name = "Напитки", Description = "Холодные напитки, чай"}
                    };


                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.Name, el);
                    }
                }

                return category;
            }
        }
    }
}

