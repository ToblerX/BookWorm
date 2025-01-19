Instrukcja pierwszego uruchomienia
1)	Jeżeli SQL Server nie jest zainstalowany lub jest z nim błąd – patrz pkt. 2. Jeżeli nie ma problemów – patrz pkt. 5.
2)	Zainstalować SQL Servera na urządzeniu, za potrzeby skonfigurować go dla pomyślnego korzystania. Pobrać SQL Server:
https://www.microsoft.com/en-us/sql-server/sql-server-downloads
SQL Server Express – zalecany. Podczas instalacji, wybierz opcję LocalDB.
3)	Jeżeli jest pobrany i skonfigurowany do działania SQL Server, ale wciąż pokazuję się błąd po typu „A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)” – proszę edytować zawartość pliku appsettings.json (parameter “ConnectionString”):

"ConnectionStrings": { 
"DefaultConnection":" Server=(localdb)\\MSSQLLocalDB;Database=BookWormDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True" }

		Lub
  
"ConnectionStrings": {
"DefaultConnection":"Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"

↑ 	Jeżeli korzystasz z SQL Server Express (zalecane) – „DefaultConnection” musi wyglądać tak jak jest napisane nad tą (czerwoną) wskazówką.

Zaleźnie od konfiguracji SQL Server.

 Jeżeli wciąż nie działa – proszę dodać do oryginalnej treści parametr „TrustServerCertificate=True” do „DefaultConnection”.
 
4)	Jeżeli wciąż nie działa, a skorzystałeś z tych rad – proszę uprzejmie zapytać ChatGPT, bo na pewno znajdzie dla ciebie szybki sposób rozwiązania 😊
5)	Po załatwieniu wszystkich spraw związanych z SQL Server, proszę wpisać polecenie „Update-Database” w Package Manager Console

Instrukcja wejścia na konto administratora:
1) Wyjdź ze swojego konta, jeżeli jesteś zalogowany
2) Naciśnij „Login”
3) Wprowadź te dane:

Email: admin@example.com
Pass: AdminPassword123!

4) Teraz możesz korzystać z dodatkowej paneli administratora, naciskając „Manage Books”
