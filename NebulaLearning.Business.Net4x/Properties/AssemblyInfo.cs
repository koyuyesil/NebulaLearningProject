using NebulaLearning.Core.Net4x.Aspects.PostSharp.LogAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.PerformanceAspect;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging.Log4Net.Loggers;
using System.Reflection;
using System.Runtime.InteropServices;

// Bir bütünleştirilmiş koda ilişkin Genel Bilgiler aşağıdaki öznitelikler kümesiyle
// denetlenir. Bütünleştirilmiş kod ile ilişkili bilgileri değiştirmek için
// bu öznitelik değerlerini değiştirin.
[assembly: AssemblyTitle("NebulaLearning.Business.Net4x")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NebulaLearning.Business.Net4x")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
// Aspecte parametre olarak namespace yazılırsa o namespace daki tüm sınıflar loglanır.
[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "NebulaLearning.Business.Net4x.Concrete.Managers.*")]
[assembly: LogAspect(typeof(FileLogger), AttributeTargetTypes = "NebulaLearning.Business.Net4x.Concrete.Managers.*")]
[assembly: LogExceptionAspect(typeof(DatabaseLogger), AttributeTargetTypes = "NebulaLearning.Business.Net4x.Concrete.Managers.*")]
[assembly: LogExceptionAspect(typeof(FileLogger), AttributeTargetTypes = "NebulaLearning.Business.Net4x.Concrete.Managers.*")]
// Burada verilen performans parametresi tüm methodlara aynı verilmiştir dilenirse aspect methoda özel eklenebilir. her iksi de çalışacaktır.
[assembly: PerformanceCounterAspect(2, AttributeTargetTypes = "NebulaLearning.Business.Net4x.Concrete.Managers.*")]
// ComVisible özniteliğinin false olarak ayarlanması bu bütünleştirilmiş koddaki türleri
// COM bileşenleri için görünmez yapar. Bu bütünleştirilmiş koddaki bir türe
// erişmeniz gerekirse ComVisible özniteliğini o türde true olarak ayarlayın.
[assembly: ComVisible(false)]

// Bu proje COM'un kullanımına sunulursa, aşağıdaki GUID tür kitaplığının kimliği içindir
[assembly: Guid("18366511-2312-48f0-a0af-c15d5df3f7cf")]

// Bir derlemenin sürüm bilgileri aşağıdaki dört değerden oluşur:
//
//      Ana Sürüm
//      İkincil Sürüm 
//      Yapı Numarası
//      Düzeltme
//
// Tüm değerleri belirtebilir veya varsayılan Derleme ve Düzeltme Numaralarını kullanmak için
// aşağıda gösterildiği gibi '*' kullanabilirsiniz:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
