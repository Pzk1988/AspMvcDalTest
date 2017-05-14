using AutoMapper;
using PANWebApp.DAL.DbModels;
using PANWebApp.DAL.DTO;
using PANWebApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PANWebApp.DAL
{
    public class DataAccess
    {
        private readonly AuthorsRepository _authorsRepository;
        private readonly BooksRepository _booksRepository;
        private readonly UsersRepository _usersRepository;
        private readonly LibraryContext _context;
        private static readonly IMapper _mapper;
        static DataAccess()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<Author, AuthorDTO>().ForMember(dto => dto.Image,
                    db => db.MapFrom(_ => Convert.FromBase64String(_.Image)));

                cfg.CreateMap<AuthorDTO, Author>().ForMember(db => db.Image,
                    dto => dto.MapFrom(_ => Convert.ToBase64String(_.Image))); ;
            }));

        }
        public DataAccess()
        {
            _context = new LibraryContext();
            _usersRepository = new UsersRepository(_context);
            _booksRepository = new BooksRepository(_context);
            _authorsRepository = new AuthorsRepository(_context);
        }

        #region User
        public bool UserExists(string login)
        {
            return _usersRepository.Exists(login);
        }

        public bool UserExists(string login, string passwordHash)
        {
            return _usersRepository.Exists(login, passwordHash);
        }

        public void CreateNewUser(UserDTO user)
        {
            User userEntity = _mapper.Map<User>(user);
            userEntity.Id = Guid.NewGuid();
            _usersRepository.Save(userEntity);
        }
        #endregion User

        #region Author
        public AuthorDTO GetAuthor(Guid id)
        {
            Author dbAuthor = _authorsRepository.Get(id);
            AuthorDTO authorDTO = new AuthorDTO()
            {
                Id = dbAuthor.Id,
                FirstName = dbAuthor.FirstName,
                LastName = dbAuthor.LastName
            };

            return authorDTO;
        }

        public AuthorDTO GetAuthorDetails(Guid id)
        {
            Author dbAuthor = _authorsRepository.Get(id);
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(dbAuthor);

            return authorDTO;
        }

        public void CreateNewAuthor(AuthorDTO authorDTO)
        {
            Author authorEntity = _mapper.Map<Author>(authorDTO);
            authorEntity.Id = Guid.NewGuid();
            _authorsRepository.Save(authorEntity);
        }

        public void UpdateAuthor(AuthorDTO authorDTO)
        {
            Author authorEntity = _mapper.Map<Author>(authorDTO);
            _authorsRepository.Save(authorEntity);
        }

        public List<AuthorDTO> GetAuthors()
        {
            List<AuthorDTO> returnValue = new List<AuthorDTO>();
            var authorEntities = _authorsRepository.GetAll();

            foreach (Author authorEntity in authorEntities)
            {
                returnValue.Add(new AuthorDTO()
                {
                    Id = authorEntity.Id,
                    FirstName = authorEntity.FirstName,
                    LastName = authorEntity.LastName
                });
            }

            return returnValue;
        }

        public void DeleteAuthor(Guid id)
        {
            _authorsRepository.Delete(id);
        }

        #endregion Author

        #region Book
        public BookDTO GetBook(Guid id)
        {
            Book dbBook = _booksRepository.Get(id);
            BookDTO bookDTO = new BookDTO()
            {
                Id = dbBook.Id,
                Title = dbBook.Title,
                Year = dbBook.Year,
            };

            return bookDTO;
        }

        public BookDTO GetBookDetails(Guid id)
        {
            Book dbBook = _booksRepository.Get(id);
            BookDTO bookDTO = _mapper.Map<BookDTO>(dbBook);
            return bookDTO;
        }

        public void CreateNewBook(BookDTO bookDTO)
        {
            Book bookEntity = _mapper.Map<Book>(bookDTO);
            bookEntity.Id = Guid.NewGuid();
            _booksRepository.Save(bookEntity);
        }

        public void UpdateBook(BookDTO bookDTO)
        {
            Book bookEntity = _mapper.Map<Book>(bookDTO);
            _booksRepository.Save(bookEntity);
        }

        public List<BookDTO> GetBooks()
        {
            List<BookDTO> returnValue = new List<BookDTO>();
            var bookEntities = _booksRepository.GetAll();

            foreach (Book bookEntity in bookEntities)
            {
                returnValue.Add(new BookDTO()
                {
                    Id = bookEntity.Id,
                    Title = bookEntity.Title,
                    Year = bookEntity.Year,
                });
            }

            return returnValue;
        }
        #endregion Book

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
