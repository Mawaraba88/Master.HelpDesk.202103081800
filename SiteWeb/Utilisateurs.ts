
//  JS Standard reconnu 
console.log("Test type script");

// classe utilisateur
class Personne {
}

class Utilisateur extends Personne {
    public Nom: string;
    public Prenom: string;
    public Ancienneté: number;
    public Adresse: any;

    public getAdresse(): string {
        return ""; 
    }

    public Profil(): void {

    }
} 

let mawaraba = new Utilisateur();
console.log(mawaraba.getAdresse());  

// JQUERY 
//$("body") .click(function(){
//todo 
//});
//$(".class").attr()
//$("#id").show()  

