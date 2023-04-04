<h1>Şehirler Uygulaması</h1><p>Bu uygulama, ASP.NET Core MVC ve ASP.NET Core Web API kullanılarak oluşturulmuştur. Web API projesinde, Entity Framework Core ve Repository Tasarım Deseni kullanılarak bir Sehirler tablosu oluşturulup CRUD işlemleri yapılmaktadır. MVC projesinde ise Web API servisi ile haberleşip bir sayfada CRUD işlemleri gerçekleştirilmektedir.</p><h2>Gereksinimler</h2><ul><li>.NET 7.0 SDK veya üstü</li><li>MS SQL Server</li><li>Visual Studio 2019 veya üstü (opsiyonel)</li></ul><h2>Yapılandırma</h2><p>Uygulama, <code>appsettings.json</code> dosyasındaki <code>ConnectionStrings</code> özelliğindeki veritabanı bağlantı dizesini kullanarak veritabanına bağlanır. Bu özellik, veritabanı sunucusu ve kullanılacak veritabanı adı gibi bilgileri içermelidir.</p><pre><div class="bg-black rounded-md mb-4"><div class="flex items-center relative text-gray-200 bg-gray-800 px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>json</span><button class="flex ml-auto gap-2"><svg stroke="currentColor" fill="none" stroke-width="2" viewBox="0 0 24 24" stroke-linecap="round" stroke-linejoin="round" class="h-4 w-4" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"></path><rect x="8" y="2" width="8" height="4" rx="1" ry="1"></rect></svg>Copy code</button></div><div class="p-4 overflow-y-auto"><code class="!whitespace-pre hljs language-json"><span class="hljs-punctuation">{</span>
  <span class="hljs-attr">"ConnectionStrings"</span><span class="hljs-punctuation">:</span> <span class="hljs-punctuation">{</span>
    <span class="hljs-attr">"DefaultConnection"</span><span class="hljs-punctuation">:</span> <span class="hljs-string">"Server=(localdb)\\mssqllocaldb;Database=City;Trusted_Connection=True;MultipleActiveResultSets=true"</span>
  <span class="hljs-punctuation">}</span>
<span class="hljs-punctuation">}</span>
</code></div></div></pre><h2>Veritabanı Oluşturma</h2><p>Uygulama, Entity Framework Core ve Code First yaklaşımı kullanarak Sehirler tablosunu oluşturur. Veritabanını oluşturmak için aşağıdaki adımları izleyin:</p><ol><li>Veritabanı sunucusu yüklü değilse, <a href="https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads" target="_new">https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads</a> adresinden indirip kurun.</li><li><code>appsettings.json</code> dosyasındaki <code>ConnectionStrings</code> özelliğindeki veritabanı bağlantı dizesini güncelleyin.</li><li>Visual Studio'da, Package Manager Console'u açın (<code>Tools &gt; NuGet Package Manager &gt; Package Manager Console</code>).</li><li>Aşağıdaki komutları Package Manager Console'da çalıştırın:</li></ol><pre><div class="bg-black rounded-md mb-4"><div class="flex items-center relative text-gray-200 bg-gray-800 px-4 py-2 text-xs font-sans justify-between rounded-t-md"></div><div class="p-4 overflow-y-auto"><code class="!whitespace-pre hljs language-powershell">cd WebAPI
Add-Migration InitialCreate
Update-Database
</code></div></div></pre><p>Bu komutlar, <code>WebAPI</code> projesindeki veritabanı tablolarını oluşturacak ve varsayılan verileri ekleyecektir.</p><h2>nLog Kullanımı</h2><p>Uygulama, nLog kütüphanesi ile loglama yapmaktadır. Loglar, <code>logs</code> klasöründe tarihleme ile kaydedilir.
