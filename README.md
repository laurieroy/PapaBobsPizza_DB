# PapaBobsPizza_DB
This is an ASP.NET project to show what we'd learned in the class, Tech Academy Oct 2017. 
An [UI spec](UIOrderForm.PNG) was given as well as certain [requirements](PapaBobsMegaChallengeRequirements.txt). Concerns are separated in layers: Web, Persistence, Domain, and the DTO transfers data between layers. 

A simple [web form](PapaBobsBlank.PNG) collects the requested size, crust and toppings for the pizza, updating the cost as items are selected. The user enters name, address, phone and method of payment. Inputs are validated and passed through to database, sending user to a success page, or [error instructions](Name_error.PNG) guide them to correct the info.
A [GridView](OrderManagement.aspx.PNG) of pizzas waiting to be made is available for the workers, and they removed form list when "Completed" is checked.
At this time, only one pizza can be ordered at once.

This was the most challenging assignment yet, and took me several tries to get it right. I named things too similarly and would confuse myself, but as in other projects, the VS I just noticed some typos as I was writing up this readme. 
