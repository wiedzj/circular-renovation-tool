const express = require('express'); // import express 
const app = express(); // initialize express

// Import our data from data.js
const productData = require('./data.js');

// Get route
app.get('/products', function (req, res) 
{
      return res.send(productData);
});

// Listen on port 3000
app.listen(3000, function () { console.log('Listening on port 3000...');});
