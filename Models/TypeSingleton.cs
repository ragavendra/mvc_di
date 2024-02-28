using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diLifeTimes_.Models
{
    public interface ITypeSingleton
    {
        public void LogMethod();
    }

    public class ClassSingleton : ITypeSingleton
    {
        public Guid Guid_ { get; set; } = Guid.NewGuid();
/*
        private TypeSingleton TypeSingleton_ { get; set; }

        private TypeScoped TypeScoped_ { get; set; }

        private TypeTransient TypeTransient_ { get; set; }

        public ClassSingleton(TypeSingleton typeSingleton, TypeScoped typeScoped, TypeTransient typeTransient)
        {
            TypeSingleton_ = typeSingleton;
            TypeScoped_ = typeScoped;
            TypeTransient_ = typeTransient;
        }*/

        public void LogMethod() {
            Console.WriteLine("Check scopes here. Singleton Guid - " + Guid_);
        }
    }


    public interface ITypeTransient
    {
        public void LogMethod();
    }

    public class ClassTransient : ITypeTransient
    {
        public Guid Guid_ { get; set; } = Guid.NewGuid();
/*
        private TypeSingleton TypeSingleton_ { get; set; }

        private TypeScoped TypeScoped_ { get; set; }

        private TypeTransient TypeTransient_ { get; set; }

        public ClassTransient(TypeSingleton typeSingleton, TypeScoped typeScoped, TypeTransient typeTransient)
        {
            TypeSingleton_ = typeSingleton;
            TypeScoped_ = typeScoped;
            TypeTransient_ = typeTransient;
        }*/


        public void LogMethod() {
            Console.WriteLine("Check scopes here. Transient Guid - " + Guid_);
        }
    }

    public interface ITypeScoped
    {
        public Guid Guid_ { get; set; }

        public void LogMethod();
    }

    public class ClassScoped : ITypeScoped
    {
        public Guid Guid_ { get; set; } = Guid.NewGuid();

        public void LogMethod() {
            Console.WriteLine("Check scopes here. Scoped Guid - " + Guid_);
        }
    }

    public class AppClass
    {

        private ITypeSingleton TypeSingleton_ { get; set; }

        private ITypeScoped TypeScoped_ { get; set; }

        private ITypeTransient TypeTransient_ { get; set; }

        public AppClass(ITypeSingleton typeSingleton, ITypeScoped typeScoped, ITypeTransient typeTransient)
        {
            TypeSingleton_ = typeSingleton;
            TypeScoped_ = typeScoped;
            TypeTransient_ = typeTransient;
        }

        public void LogCall()
        {
            Console.WriteLine("Check scopes here ");
        }
    }

}
