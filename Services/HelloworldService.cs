public class HelloworldService: IHelloworldService{
    public string GetHelloWorld(){
        return "Hello World";
    }
}


//INTERFACE
public interface IHelloworldService{
    string GetHelloWorld();
}