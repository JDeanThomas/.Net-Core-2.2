###Quickly add setup folders (add Product.cs to Models)
mkdir Models && touch $_/Product.cs

###Add Data folder w Context and Seed files
mkdir Data && touch $_/ProductsContext.cs $_/SeedData.cs

###Create Controlers files
touch ./Controllers/ProductsController.cs

###Run app in background and log
dotnet run > RetailApi.log &

####Invalid request
curl -v -k \
    -H "Content-Type: application/json" \
    -d "{\"name\":\"Plush Squirrel\",\"price\":0.00}" \
    https://localhost:5001/api/Products
	
####Valid requests
curl -v -k \
    -H "Content-Type: application/json" \
    -d "{\"name\":\"Plush Squirrel\",\"price\":12.99}" \
    https://localhost:5001/api/Products
	
####Get	
curl -k -s https://localhost:5001/api/Products/3 | python -m json.tool

####Put
curl -k -X PUT \
    -H "Content-Type: application/json" \
    -d "{\"id\":2,\"name\":\"Knotted Rope\",\"price\":14.99}" \
    https://localhost:5001/api/Products/2
	
####Delete
curl -v -k -X DELETE https://localhost:5001/api/Products/1

####Get
curl -k -s https://localhost:5001/api/Products | python -m json.tool


###Stop server using PID
kill $(pidof dotnet)


