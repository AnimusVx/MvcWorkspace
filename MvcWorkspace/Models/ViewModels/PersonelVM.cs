namespace MvcWorkspace.Models.ViewModels
{
    public class PersonelVM
    {
        public int PersonelCount { get; set; }      
        public IEnumerable<Personel> PersoneListe { get; set; }
        public IEnumerable<Bolum> bolum { get; set; }
        //IEnum olarak yazma sebebimiz
        //Bolum class'ı içindeki propların hepsine aynı işlemleri yaptırabilir hale getirebilmek için. 
        //Minimum içini gezebilir hale getirmek için.
    }
}
