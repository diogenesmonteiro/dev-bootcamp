using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using StudentEnrolmentWebApp.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace StudentEnrolmentWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvc().AddXmlDataContractSerializerFormatters();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentEnrolmentWebApp", Version = "v1" });
            });
            services.AddDbContext<ApiStudentEnrolmentDbContext>(option => 
                option.UseMySQL("persistsecurityinfo=True;password=abcd1234;user id=devuser;server=localhost;database=StudentEnrolment;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApiStudentEnrolmentDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentEnrolmentWebApp v1"));
            }
            
            if(!DatabaseFacadeExtensions.Exists(dbContext.Database))
            {
                dbContext.Database.Migrate();
                dbContext.Database.ExecuteSqlRaw(
                    @"INSERT INTO Students (FirstName, LastName) VALUES ('Aaron', 'Tremblay'), ('Helena', 'Daugherty'), ('Cloyd', 'Upton'), ('Daren', 'Leffler'), ('Wilber', 'Zemlak'), ('Loraine', 'Larkin'), ('Holly', 'Pouros'), ('Martin', 'Heaney'), ('Alta', 'Wintheiser'), ('Roberto', 'Carroll'), ('Tiara', 'Herman'), ('Isabella', 'Kreiger'), ('Malika', 'Veum'), ('Laura', 'OReilly'), ('Devon', 'Jerde'), ('Bridgette', 'Tremblay'), ('Stanford', 'Balistreri'), ('Jacey', 'Connelly'), ('Ashly', 'Dare'), ('Mya', 'Baumbach'), ('Elroy', 'Lowe'), ('Aubree', 'Donnelly'), ('Darion', 'Emard'), ('Webster', 'Donnelly'), ('Lilian', 'Kohler'), ('Orion', 'Stokes'), ('Hector', 'Green'), ('Keaton', 'Klocko'), ('Waylon', 'Fritsch'), ('Megane', 'Kerluke'), ('Julianne', 'Howe'), ('Gene', 'Mayer'), ('Eryn', 'Bernhard'), ('Lyric', 'Littel'), ('Mavis', 'Jacobs'), ('Miracle', 'Beahan'), ('Stacy', 'Macejkovic'), ('Jarred', 'Wunsch'), ('Lamont', 'Pfeffer'), ('Chauncey', 'Jakubowski'), ('Philip', 'Hand'), ('Guido', 'Wisozk'), ('Alexie', 'Larkin'), ('Providenci', 'Abbott'), ('Melba', 'Watsica'), ('Josefina', 'Aufderhar'), ('Hubert', 'Runolfsdottir'), ('Leo', 'Johnson'), ('Margarett', 'Abernathy'), ('Madelyn', 'Lehner');");
                dbContext.Database.ExecuteSqlRaw(
                    @"INSERT INTO Courses (Name, Description, IsPartFunded) VALUES ('Anthropology Degree', 'Anthropology is a people-oriented degree that establishes foundations in a range of subjects and requires transferable skills.', False), ('Physiotherapy Degree', 'Physiotherapy is a specialist branch of medicine that helps improve impairments in movement. It aims to improve a patient?s quality of life through physical intervention to help mobility and function.', True), ('Natural Sciences Degree', 'Natural science focusses on developing an understanding of the natural world. It explores the natural work from several perspectives, including chemical, physical, mathematical, environmental and geological.', False), ('Computer Science Degree', 'A computer science degree is the focus of theoretical principles surrounding computation, often combined with scientific theories and their application in real-world environments. It often uses protocols and algorithms to process data.', True);");
                dbContext.Database.ExecuteSqlRaw(
                    @"INSERT INTO Subjects (Name, Description) VALUES ('Intro to the Scientific Study of Language', 'Overview of the scientific study of the structure and function of language. Introduces the main fields of linguistics: phonetics, phonology, morphology, syntax, semantics, discourse, historical linguistics, sociolinguistics, and psycholinguistics. Highlights the interdisciplinary relationship of linguistics with anthropology, sociology, psychology, and cognitive sciences.'), ('Revolutions and Utopias', 'In order to gain a more precise grasp of our contemporary political challenges and possibilities, this course in political anthropology investigates a wide range of historical and contemporary cases of rapid political and social transformation and carefully examines the ideas, desires and utopias that inspired them.'), ('Law and Resistance', 'This course will explore how people interact with the law in their everyday lives ? in the U.S. and elsewhere. Examples will include how individuals experience and respond to policing, examining the effects of immigration and border security policies, and tracing how people and groups mobilize to challenges laws perceived as unjust. '), ('People and Animals in the Past', 'This course asks students to consider the human as a special kind of animal, and the roles of other animals in our human worlds: as companions, spirits, artistic muses, laborers, and as sources of food, clothing, shelter, and tools. We examine how human-animal relationships have changed over time, and consider human impacts upon animals and environments at multiple scales: from continental and island colonizations, to local extirpations and global extinctions. While our scope is both geographically and temporally broad, specific case studies will be highlighted from Africa, Eurasia, North America, and the Pacific islands.'), ('Neurosciences 1', 'Understanding the normal functioning of the peripheral and central nervous systems and how they are affected by disease. ? Developing skills of analysing normal and abnormal movement allowing students to clinically reason. ? The tools needed to assess the patient with a neurological impairment to identify an effective management plan.'), ('Cardiorespiratory 1', 'Module	Credits	Compulsory/optional Foundations for Physiotherapy Practice	30 Credits	Compulsory Cardiorespiratory 1	15 Credits	Compulsory The student will learn about the normal f unction of the cardiovascular and respiratory systems and how they are affected by disease. The focus of the module will be developing the following skills for students: ? Assessing the patient with cardiorespiratory dysfunction, identifying their problems using clinical reasoning skills.'), ('Foundations for Physiotherapy Practice', 'The student will be introduced to the systems of the body, movement analysis, motor learning and therapeutic exercise prescription. The focus of the module will be on developing the following skills: ? Movement analysis ? The safe and effective application of therapeutic exercise for healthy individuals and across a range of special populations.'), ('Musculoskeletal 1', 'During this module students will cover the anatomy, biomechanics and common pathologies affecting patients who have dysfunction in the lower limb and lumbar spine. The focus of the module will be developing the following skills for students: ? Clinical reasoning skills to develop safe and effective assessment, treatment and management plans and to evaluate their outcomes.'), ('Astrophysics', 'There are eight 24-lecture courses spread over Michaelmas and Lent Terms, which teach the fundamental physics underlying the course and the main areas of contemporary astronomy - viz relativity, quantum mechanics, cosmology, stars, physics of astrophysics, dynamics, fluids and statistical physics.'), ('Chemistry', 'The course builds on the ideas which were presented in the first and second year, and offers students the opportunity to both broaden and deepen their knowledge of chemistry. As the year progresses there is the opportunity for students to narrow their focus somewhat, for example towards chemical biology or chemical physics; however, they can equally well choose to pursue a broad range of topics across all areas of chemistry. '), ('Pathology', 'This course offers study in the main constituent disciplines of Pathology. In order to facilitate study in depth each discipline is presented as an optional subject.'), ('Psychology, Neuroscience and Behaviour', 'The neurosciences are one of the most exciting and fast moving areas in biology and these features are well represented in this interdepartmental course. Neurosciences are noted for the breadth of their theoretical base in diverse areas of modern biology and in the range of their medical and social applications.'), ('Programming 1', 'This module teaches students the fundamentals of programming in Java. Students will learn to develop and debug simple programs using basic programming concepts.'), ('Concepts of Computer Science', 'This module along with CS-155 gives an overview of some of the main principles underlying computers and computing from both a theoretical and an applied point of view. Following a brief history of computers and software an introduction to the representation of data and the basic components of a computer will be given.'), ('Programming 2', 'This module is a continuation of the module CS-110 Programming 1. In it, students will continue to enhance their skills in programming, as well as gain a basic understanding of algorithms and data structures.'), ('Modelling Computing Systems', 'This module will follow on from CS-170 and introduces students to mathematical tools and techniques for modeling computing systems.');");
                dbContext.Database.ExecuteSqlRaw(
                    @"INSERT INTO CourseMemberships (StudentId, CourseId) VALUES ('1', '1'), ('2', '3'), ('3', '2'), ('4', '4'), ('5', '4'), ('6', '1'), ('7', '2'), ('8', '3'), ('9', '4'), ('10', '4'),('11', '2'), ('12', '1'), ('13', '2'), ('14', '2'), ('15', '4'), ('16', '1'), ('17', '4'), ('18', '4'), ('19', '3'), ('20', '2'), ('21', '4'), ('22', '4'), ('23', '1'), ('24', '1'), ('25', '2'), ('26', '2'), ('27', '3'), ('28', '1'), ('29', '4'), ('30', '2'), ('31', '3'), ('32', '4'), ('33', '2'), ('34', '3'), ('35', '1'), ('36', '3'), ('37', '2'), ('38', '3'), ('39', '4'), ('40', '2'), ('41', '3'), ('42', '3'), ('43', '1'), ('44', '1'), ('45', '1'), ('46', '3'), ('47', '3'), ('48', '4'), ('49', '1'), ('50', '4');");
                dbContext.Database.ExecuteSqlRaw(
                    @"INSERT INTO CourseSubjects (CourseId, SubjectId) VALUES ('1', '1'), ('1', '2'), ('1', '3'), ('1', '4'), ('2', '5'), ('2', '6'), ('2', '7'), ('2', '8'), ('3', '9'), ('3', '10'), ('3', '11'), ('3', '12'), ('4', '13'), ('4', '14'), ('4', '15');");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static class DatabaseFacadeExtensions
        {
            public static bool Exists(DatabaseFacade source)
            {
                return source.GetService<IRelationalDatabaseCreator>().Exists();
            }
        }
    }
}
