const psychologyModel = require('../models/psychologyModel');

exports.getTips = (req, res) => {
    const domain = req.query['domain'];
    const tips = psychologyModel.getAllAdvices({ domain });
    res.render('tipsListView', { tips });
};

exports.getTip = (req, res) => {
    const id = parseInt(req.params['id'], 10);
    const tip = psychologyModel.getAdviceById(id);
    res.render('tipView', { tip });
};

exports.createTip = (req, res) => {
    const tips = psychologyModel.getAllAdvices().sort((a, b) => a - b);
    const maxId = tips[tips.length - 1].id;
    const newTip = { id: maxId + 1, value: req.body.value, domain: req.body.domain };
    psychologyModel.addTip(newTip);
    res.redirect('/');
};