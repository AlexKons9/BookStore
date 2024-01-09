using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelsConfiguration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
            (
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "William",
                    LastName = "Shakespeare",
                    Biography = "William Shakespeare (bapt.Tooltip baptised 26[a] April 1564 – " +
                    "23 April 1616)[b] was an English playwright, poet and actor. He is widely " +
                    "regarded as the greatest writer in the English language and the world's " +
                    "pre-eminent dramatist.[3][4][5] He is often called England's national poet " +
                    "and the \"Bard of Avon\" (or simply \"the Bard\"). His extant works, including " +
                    "collaborations, consist of some 39 plays, 154 sonnets, three long narrative poems, " +
                    "and a few other verses, some of uncertain authorship. His plays have been translated " +
                    "into every major living language and are performed more often than those of any " +
                    "other playwright.[6] Shakespeare remains arguably the most influential writer " +
                    "in the English language, and his works continue to be studied and reinterpreted."
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Agatha",
                    LastName = "Cristie",
                    Biography = "Dame Agatha Mary Clarissa Christie, Lady Mallowan, DBE (née Miller; " +
                    "15 September 1890 – 12 January 1976) was an English writer known for her 66 detective " +
                    "novels and 14 short story collections, particularly those revolving around fictional " +
                    "detectives Hercule Poirot and Miss Marple. She also wrote the world's longest-running " +
                    "play, the murder mystery The Mousetrap, which has been performed in the West End " +
                    "since 1952. A writer during the \"Golden Age of Detective Fiction\", Christie has " +
                    "been called the \"Queen of Crime\". She also wrote six novels under the pseudonym " +
                    "Mary Westmacott. In 1971, she was made a Dame (DBE) by Queen Elizabeth II for her " +
                    "contributions to literature. Guinness World Records lists Christie as the best-selling " +
                    "fiction writer of all time, her novels having sold more than two billion copies."
                }
            );
        }
    }
}
