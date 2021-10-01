using System;
using System.Collections.Generic;

namespace summerWork2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        public static void addFoodToSuper(superGreenFood super)
        {
            string foodName, companyName, mainTaste;
            int ml;
            double price;

            string temp;

            while (true)
            {
                Console.Write("Enter food name: ");
                temp = Console.ReadLine();
                if (temp == "the end")
                {
                    return;
                }
                foodName = temp; 

                Console.Write("Enter company name: ");
                temp = Console.ReadLine();
                if (temp == "the end")
                {
                    return;
                }
                companyName = temp;

                Console.Write("Enter main taste: ");
                temp = Console.ReadLine();
                if (temp == "the end")
                {
                    return;
                }
                mainTaste = temp;

                Console.Write("Enter ml: ");
                temp = Console.ReadLine();
                if (temp == "the end")
                {
                    return;
                }
                ml = int.Parse(temp);

                Console.Write("Enter price: ");
                temp = Console.ReadLine();
                if (temp == "the end")
                {
                    return;
                }
                price = double.Parse(temp);

                super.addFood(new greenFood(foodName, companyName, mainTaste, ml, price));


            } 
        }

        public static string cheaperMarket(superGreenFood super1, superGreenFood super2)
        {
            double super1Price = 0, super2Price = 0;
            for (int i = 0; i < 1000 || super1.GetFoods()[i] != null; i++)
            {
                for (int j = 0; j < 1000 || super2.GetFoods()[j] != null; j++)
                {
                    if (super1.GetFoods()[i] == super2.GetFoods()[j])
                    {
                        super1Price += super1.getPriceOfFood(super1.GetFoods()[i].GetFoodName());
                        super2Price += super2.getPriceOfFood(super2.GetFoods()[j].GetFoodName());
                    }
                }
            }

            return super1Price < super2Price ? super1.getName() : super2.getName();
        }

    }

    

    class greenFood
    {
        private string _foodName;
        private string _companyName;
        private string _mainTaste;
        private int _ml;
        private double _price;

        public greenFood(string foodName, string comapnyName, string mainTaste, int ml, double price)
        {
            this._foodName = foodName;
            this._companyName = comapnyName;
            this._mainTaste = mainTaste;
            this._ml = ml;
            this._price = price;

            
        }

        public void SetFoodName(string foodName)
        {
            this._foodName = foodName;
        }

        public void CompanyFoodName(string companyName)
        {
            this._companyName = companyName;
        }

        public void SetMainTaste(string mainTaste)
        {
            this._mainTaste = mainTaste;
        }

        public void SetML(int ml)
        {
            this._ml = ml;
        }

        public void SetPrice(double price)
        {
            this._price = price;
        }

        public string GetFoodName()
        {
            return this._foodName;
        }

        public string GetCompanyName()
        {
            return this._companyName;
        }

        public string GetMainTaste()
        {
            return this._mainTaste;
        }

        public int GetML()
        {
            return this._ml;
        }

        public double GetPrice()
        {
            return this._price;
        }

    }

    class superGreenFood
    {
        private string _name;
        private greenFood[] _food;
        private int _foodCount;

        public superGreenFood(string name)
        {
            this._name = name;
            this._food = new greenFood[1000];
            this._foodCount = 0;
        }

        public void addFood(greenFood food)
        {
            if (this._foodCount < 1000)
            {
                this._food[_foodCount] = food;
                this._foodCount++;
            }
            else
            {
                Console.WriteLine("couldn't add food to list, out of space");
            }
        }

        public string getName()
        {
            return this._name;
        }
        public greenFood[] GetFoods()
        {
            return this._food;
        }
        public int getFoodCount()
        {
            return this._foodCount;
        }

        public void setName(string name)
        {
            this._name = name;
        }

        public void setFoods(greenFood[] foods)
        {
            int count = 0;
            for (int i = 0; i < foods.Length && foods[i] != null; i++)
            {
                count++;
            }
            this._food = foods;
            this._foodCount = count;
        }

        public string[] getCheapestFood()
        {
            string[] cheapestFood = new string[2];
            double cheapest = 0;

            if (this._foodCount > 0)
            {
                cheapest = (this._food[0].GetPrice() / this._food[0].GetML());
                cheapestFood[0] = this._food[0].GetFoodName();
                cheapestFood[1] = this._food[0].GetCompanyName();
                for (int i = 0; i < this._foodCount; i++)
                {
                    if ((this._food[i].GetPrice() / this._food[i].GetML()) < cheapest)
                    {
                        cheapest = (this._food[i].GetPrice() / this._food[i].GetML());
                        cheapestFood[0] = this._food[i].GetFoodName();
                        cheapestFood[1] = this._food[i].GetCompanyName();
                    }
                }
            }
            return cheapestFood;
        }

        public double getPriceOfFood(string foodName)
        {
            double price = 0;
            for (int i = 0; i < this._foodCount; i++)
            {
                if (this._food[i].GetFoodName() == foodName)
                {
                    price = this._food[i].GetPrice();
                }
            }
            return price;
        }

        public int countFoodsOfCompany(string companyName)
        {
            List<string> foods = new List<string>();

            for (int i = 0; i < this._foodCount; i++)
            {
                if (this._food[i].GetCompanyName() == companyName)
                {
                    bool doesExist = false;
                    for (int j = 0; j < foods.Count; j++)
                    {
                        if (foods[j] == this._food[i].GetFoodName())
                        {
                            doesExist = true;
                        }
                    }
                    if (!doesExist)
                    {
                        foods.Add(this._food[i].GetFoodName());
                    }
                }
                    
            }
            return foods.Count;
        }

    
    }

    
}
