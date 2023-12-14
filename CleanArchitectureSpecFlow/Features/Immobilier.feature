Feature: Immobilier

Immobilier endpoint


@add_immobilier
Scenario: add Immobolier
	add new immobilier to the immobilier collection
	Given there are Immobolier in the system
	When I make a POST request on 'api/v1/immobilier' with this data:
	| description | localisation | typeImmobilier | typeVente | image | prix | avance | utilisateurId | publier | fullDescription
	| descrip_one | loc_one      |      1         |     1     |img_one| 12340| 2 mois |   1           | false   |fulldescrip
	Then a successful response is returned with the newly added Immobolier
	And the response status code is 200

@get_all_immobilier
Scenario: Get all Immobolier
	Retrieve all published immobilier from the immobilier endpoint
	Given there are Immobolier in the system
	When I make a GET request on 'api/v1/immobilier'
	Then a successful response is returned with a list of Immobolier
	And the response status code is 200