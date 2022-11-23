using VoeAirlines.Entities; //é o modelo do projeto (model-dados)
using Microsoft.EntityFrameworkCore; //ORM
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlines.EntityConfigurations;

public class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    /*
       6 minutos
       Qual a diferença entre uma classe e uma interface?
    */
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        //Definindo a tabela
        //pluralização
        builder.ToTable("Logins");

        //única, imutável e universal
        //Chave Primária 
        /*
           x=5,y=7;
           function somar(int x,int y){
                return x y;
           }

           public int Somar(int x,int y){
               return x y;
           }
           
           anônima...(você não tem o nome da função)
           mas você tem a funcionalidade.
           (s => s.x s.y); ---> lambda functions
           var res = s=>s.x s.y
        */
        builder.HasKey(l=>l.Id);//única,imutável,universal
        //Definir usuário
        builder.Property(l=>l.Usuario)
               .IsRequired()
               .HasMaxLength(40);
        //Definir senha
        builder.Property(l=>l.Senha)
               .IsRequired()
               .HasMaxLength(12); 

    }
}





