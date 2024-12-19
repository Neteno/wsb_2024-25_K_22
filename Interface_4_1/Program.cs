namespace Interface_4_1
{
    internal class Program
    {
        public interface IAnimal
        {
            void MakeSoud();
            void Eat();
        }
        public abstract class Animal : IAnimal
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Animal(string name,int age)
            {
                Name = name;
                Age = age;
            }
            public void Eat()
            {
                Console.WriteLine($"{Name} je");
            }
            public abstract void MakeSoud();
        }

        public class Dog : Animal
        {
            public Dog(string name, int age) : base(name, age)
            {
            }
            public override void MakeSoud()
            {
                Console.WriteLine("Hau Hau !!");
            }
        }

        public class Cat : Animal
        {
            public Cat(string name, int age) : base(name, age)
            {
            }

            public override void MakeSoud()
            {
                Console.WriteLine("Miau miau!!");
            }
        }
        static void Main(string[] args)
        {
            Dog dog = new Dog("Azor",2);
            dog.Eat();
            dog.MakeSoud();

            Cat cat = new Cat("Mruczek",4);
            cat.Eat();
            cat.MakeSoud();
            Console.Clear();

            var animals = new List<Animal>()
            {
                dog ,cat,
                new Dog("Wilk",3),
                new Cat("Mruk",7)
            };

            foreach (Animal animal in animals)
            {
                animal.MakeSoud();
                animal.Eat();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
