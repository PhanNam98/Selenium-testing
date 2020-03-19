var mongoose = require('mongoose');
var Form = require('../models/form')

module.exports=function addForm(req, res)
{
    const form = new Form({
        _id: mongoose.Types.ObjectId(),
        element_id: req.body.element_id,
        name: req.body.name,
        class: req.body.class,
        url_id:req.body.url_id
       
    })
    form.save()
        .then((newForm) => {
            return res.status(200).json({
                success: true,
                message: 'New form created successfully',
                Course: newForm,
            });
        })
        .catch((error) => {
            console.log(error);
            res.status(500).json({
                success: false,
                message: 'Server error. Please try again.',
                error: error.message,
            });
        });
};