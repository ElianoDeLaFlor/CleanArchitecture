Feature: Immobilier

Immobilier endpoint


@add_immobilier
Scenario: add Immobolier
	add new immobilier to the immobilier collection
	Given there are Immobolier in the system
	When I make a POST request on 'api/v1/immobilier' with this data:
	| description | localisation | typeImmobilier | typeVente | image | prix | avance | utilisateurId | publier | fullDescription
	| descrip_one | loc_one      |      1         |     1     |img_one| 12340| 2 mois |   1           | false   |fulldescrip
	Then the response status code is 200
	And a successful response is returned with the newly added Immobolier

@get_all_immobilier
Scenario: Get all Immobolier
	Retrieve all published immobilier from the immobilier endpoint
	Given there are Immobolier in the system
	When I make a GET request on 'api/v1/immobilier'
	Then the response status code is 200
	And a successful response is returned with a list of Immobolier

@get_by_id_immobilier
Scenario:Get Immobilier by Id
	Retrieve immobilier based on it is Id
	Given The immobilier Id is '98765432-10fe-dcba-0987-6543210fedcba'
	When I make a GET request on 'api/v1/immobilier' endpoint
	Then the response status code is 200
	And a successful response is returned with the the retrieved immobillier data

@get_by_reff_immobilier
Scenario:Get Immobilier by Reff
	Retrieve immobilier based on it is Reff
	Given The immobilier Reff is 'IMMO-002'
	When I made a GET request on 'api/v1/immobilier' endpoint with the reff
	Then the response status code is 200
	And a successful response is returned with the the retrieved immobillier data
