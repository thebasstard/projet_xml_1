using System;
using System.Collections.Generic;
using System.Data.SqlClient;//pour se connecter à unebase de données SQL
using System.IO;//pour utiliser StreamReader 
using System.Windows.Forms;
using System.Xml.Serialization; //Pour utiliser la serialization

namespace Projet_XML_1
{
    public partial class Form1 : Form
    {
        public object button1_click;

        private string Chiffre;
        private int c;
        private bool button1WasClicked;

        public Form1()
        {
            InitializeComponent();

            this.textBox1.Show();//pour afficher la textbox

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Form1 myForm = new Form1();
            myForm.Show();*/

            /*

            OpenFileDialog OpenFileDialog = new OpenFileDialog();//connection à un dossier

            if (OpenFileDialog.ShowDialog() == DialogResult.OK) //si arrive à se connecter 
                                                                //au fichier 
            {
                var Chemin = OpenFileDialog.FileName; //chemin du fichier

                /*

                if (!System.IO.File.Exists(Chemin)) //si le chemin du fichier n'existe pas
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(Chemin))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);

                            // Create a string array with the lines of text
                            string[] lines = { "First line", "Second line", "Third line","4" };

                            // Set a variable to the My Documents path.
                            string mydocpath =
                                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                            // Write the string array to a new file named "WriteLines.txt".
                            using (StreamWriter outputFile = new StreamWriter(Chemin))
                            {
                                foreach (string line in lines)
                                    outputFile.WriteLine(line);
                            } 
                        }
                    }
                }
                else
                {
                    //crée un chiffre random
                    Random rnd = new Random();
                    int chiffre = rnd.Next(1, 100);

                    //copie le fichier au cas où
                    System.IO.File.Copy( Chemin , Chemin + chiffre);

                    // Create a string array with the lines of text
                    string[] lines = { "First line", "Second line", "Third line", "4" };

                    // Set a variable to the My Documents path.
                    string mydocpath =
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    // Write the string array to a new file named "WriteLines.txt".
                    using (StreamWriter outputFile = new StreamWriter(Chemin))
                    {
                        foreach (string line in lines)
                            outputFile.WriteLine(line);
                    }
                }

                */
            /*
            List<Person> ListeDePerson = new List<Person>();

            Person p1 = new Person();

            p1.Firstname = "Xavier";
            p1.Lastname = "Dang";


            Person p2 = new Person();
            p2.Firstname = "Adrien";
            p2.Lastname = "Nougaret";

            ListeDePerson.Add(p1);
            ListeDePerson.Add(p2);


            foreach (var item in ListeDePerson)
            {

                System.Xml.XmlTextWriter myXmlTextWriter = new XmlTextWriter(Console.Out);
                myXmlTextWriter.WriteStartElement("ArrayOfPerson");

                Person MaPerson = (Person)item;

                XmlSerializer xs = new XmlSerializer(typeof(Person));
                using (StreamWriter wr = new StreamWriter(Chemin))
                {
                    xs.Serialize(wr, MaPerson);

                }

            }


            List<Adresse> ListeAdresse = new List<Adresse>();

            Adresse Adress = new Adresse();

            Adress.Firstname = p1.Firstname;
            Adress.Lastname = "Dang";
            Adress.City = "Les Coteaux";

            ListeAdresse.Add(Adress);

            foreach (var itemAdresse in ListeAdresse)
            {

                Adresse MaPersonAdresse = (Adresse)itemAdresse;

                XmlSerializer x = new XmlSerializer(typeof(Adresse));
                using (StreamWriter w = new StreamWriter(Chemin))
                {
                    x.Serialize(w, MaPersonAdresse);

                }

            }



            //p1.Detail();
            //p2.Detail();


            //exemple de tableau//
            string[] MesBurnes = new string[4];

            MesBurnes[0] = "poils";
            MesBurnes[1] = "peau";
            MesBurnes[2] = "couleur";
            MesBurnes[3] = "morpions";

            for (int k = 0; k < MesBurnes.Length; k++)
            {
                Console.WriteLine(k + " - " + MesBurnes[k]);

            }
            ///////////////////////
            */

            /*
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            using (StreamWriter wr = new StreamWriter(Chemin))
            {
                xs.Serialize(wr, p1);

            }
            */




            /*

            XmlSerializer Serialize = new XmlSerializer(typeof(List<Person>));

            StreamReader reader = new StreamReader(Chemin); //Initialise une nouvelle 
                                                            //instance de StreamReader


            var Input = Serialize.Deserialize(reader);//fichier deserialisé
            //var Input = xs.Deserialize(reader);
            dataGridView1.DataSource = Input; //résultat dans le dataGridview (tableau) 
            */



            /*
            //Create a writer to write XML to the console.
            XmlTextWriter writer = null;
            writer = new XmlTextWriter(Console.Out);

            //Use indentation for readability.
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;

            //Write an element (this one is the root).
            writer.WriteStartElement("book");

            //Write the title element.
            writer.WriteStartElement("title");
            writer.WriteString("Pride And Prejudice");
            writer.WriteEndElement();

            //Write the close tag for the root element.
            writer.WriteEndElement();

            //Write the XML to file and close the writer.
            writer.Close();



        }*/

            /////////////////////////////////////////////////////////////////////////////////////////////

             

            /*if (button1WasClicked)
            {*/
            // MessageBox.Show("ok");


            OpenFileDialog OpenFileDialog = new OpenFileDialog();//connection à un dossier

                //si arrive à se connecter au fichier
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)  
                {

                    var Chemin = OpenFileDialog.FileName; //chemin du fichier à chercher
                                                          //var Chemin = "C:\\Users\\ludov\\Desktop\\PersonsC.xml";

                    //on crée la liste
                    List<Person> ListeDePersonne = new List<Person>();
                    List<Adresse> ListeAdresse = new List<Adresse>();


                    //connexion à la base de données

                    string SQL_STRING = "server=(local); database=streamer; integrated security=true";

                    SqlConnection Conn = new SqlConnection(SQL_STRING);

                    Person p1 = new Person();
                    Adresse A1 = new Adresse();
                    //string Chiffre = textBox1.Text;
                    //MessageBox.Show(textBox1.Text);

                    Conn.Open();

                    

                    p1.id = 1;
                    //p1.id = Convert.ToInt32(textBox1.Text);
                    //p1.id = int.Parse(textBox1.Text);
                    //p1.id = Convert.ToInt32(button1.Chiffre);
                    
                    //p1.id = c;



                    SqlCommand requete = new SqlCommand("select * from Person where Id=@id", Conn);
                    requete.Parameters.AddWithValue("@id", p1.id);


                    SqlDataReader resultat = requete.ExecuteReader();

                    //if (resultat.Read())
                    while(resultat.Read())
                    {
                        p1.id = Convert.ToInt32(resultat["Id"]);
                        //p1.Lastname = Convert.ToString(resultat["Nom"]).Replace(" ", string.Empty);
                        p1.Lastname = Convert.ToString(resultat["Nom"]);
                        p1.Firstname = Convert.ToString(resultat["Prenom"]);
                        A1.City = Convert.ToString(resultat["Ville"]);
                    }





                    //exemple ecrit en dur////////
                    Person p2 = new Person();
                    p2.id = 2;
                    p2.Firstname = "Adrien      ".Trim();//pour retirer les espaces
                    p2.Lastname = "Nougaret  ".Replace(" ", string.Empty);//aussi pour retirer les espaces
                    Adresse A2 = new Adresse();
                    A2.City = "Montpellier";

                    Person p3 = new Person();
                    p3.id = 4;
                    p3.Firstname = "Elias";
                    p3.Lastname = "Lönn";
                    Adresse A3 = new Adresse();
                    A3.City = "Malmö";
                    /////////////////////////////


                    //on ajoute les objets à la liste
                    ListeDePersonne.Add(p1);
                    ListeDePersonne.Add(p2);
                    ListeDePersonne.Add(p3);
                    ListeAdresse.Add(A1);
                    ListeAdresse.Add(A2);
                    ListeAdresse.Add(A3);



                    XmlSerializer xs = new XmlSerializer(typeof(List<Person>));

                    Stream stream = File.OpenWrite(Chemin); //copie dans le fichier

                    //crée un fichier supplémentaire
                    //Stream stream2 = File.OpenWrite(Environment.CurrentDirectory + "\\MonText.xml");

                    xs.Serialize(stream, ListeDePersonne);//on serialize

                    stream.Close();//on ferme

                
                    StreamReader Sreader = new StreamReader(Chemin); //Initialise une nouvelle 
                                                                     //instance de StreamReader

                    var Input = xs.Deserialize(Sreader);//on deserialize
                    dataGridView1.DataSource = Input; //résultat dans le dataGridview (tableau) 
                
                    
                }

            //}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            
            Chiffre = textBox1.Text;
            if (Chiffre != "")
            {
                c = Convert.ToInt32(Chiffre);
                //MessageBox.Show(Convert.ToString(c));
            }
            else
            {
                MessageBox.Show("Le textbox est vide");
            }

            button1WasClicked = true;
        }


    }
}
