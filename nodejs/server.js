// import dependencies
var express= require('express');
var bodyParser =require('body-parser');
var mongoose =require('mongoose');
var logger =require('morgan');
var route =require ('./routes/route');
// set up dependencies
const app = express();
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(logger('dev'));

mongoose.connect("mongodb+srv://theboxx:123@cluster-nam-rccbg.mongodb.net/ElementDB?retryWrites=true&w=majority", { useNewUrlParser: true, useUnifiedTopology: true })
  .then(()=> {
    console.log('Database connected');
  })
  .catch((error)=> {
    console.log('Error connecting to database');
  });
  const port = 3000;
// set up route
app.get('/', (req, res) => {
  res.status(200).json({
    message: 'Welcome to Project with Nodejs Express and MongoDB',
  });
});

// set up route
app.use('/api', route);
app.listen(port, () => {
  console.log(`Our server is running on port ${port}`);
});