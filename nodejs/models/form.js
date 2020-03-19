var mongoose = require('mongoose');
var Schema = mongoose.Schema;
mongoose.set('useCreateIndex', true);
var FormSchema = new Schema({

  url_id: {
    type: String,
    index: { unique: true }
  },
  element_id: {
    type: String,
    required: true,
    index: { unique: true }
  },
  name: {
    type: String,
    index: { unique: true },
    default:""

  },
  class_name: {
    type: String,
    index: { unique: true },
    default:""

  },

});
FormSchema.index({
  name: 'text'
}, {
  weights: {
    name: 5
  },
});
module.exports = mongoose.model("Form", FormSchema);