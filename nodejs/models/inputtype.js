var mongoose = require('mongoose');
var Schema =mongoose.Schema;
mongoose.set('useCreateIndex', true);
var InputtypeSchema=new Schema({
   
    element_id:{
        type:String,
        required:true,
        index: { unique: true }
    },
    name:{
        type:String,
        index: { unique: true }
       
    },
    class_name:{
        type:String,
        index: { unique: true }
       
    },
    parent_id:{
        type:String
    },
    type:{
        type:String
    },
    value:{
        type:String
    }
});
InputtypeSchema.index({
    name: 'text'
  }, {
    weights: {
      name: 5
    },
  });
module.exports = mongoose.model("InputType", InputtypeSchema);