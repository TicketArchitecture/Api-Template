This project is supposed to help developers create a lean, robust and easily evolvable Web API project.
<p>
<b>Our mindset:</b>
<ul>
<li>Use IoC/DI only when really needed, according to our mindset.</li>
<li>Separate query from commands (a bit of CQRS), without the complexities of event sourcing and asynchronous commands.</li>
<li>Query the database straight from Controllers, change the state of database only in the application layer.</li>
<li>For versioned APIs (usually public/mobile APIs are), resolve all specific business details in a separate assembly.
<p>When this version is retired, all you need to do is delete the assembly and some routes from your solution.</li>
<li>Test your Domain Entities behavior.</li>
<li>Separate your bussiness (Domain Entities) from your Representations (Models).</li>
<li>Have different classes to different visions/stages from the same Entities.</li>
</ul>
</p>