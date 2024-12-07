const express = require('express');
const router = express.Router();
const psychologyController = require('../controllers/psychologyController');

const iconMw = (req, res, next) => {
    // just ignore it
    if (req.method === 'GET' && req.url.includes('favicon')) {
        return res.send();
    }

    return next();
}

router.use(iconMw);

router.get('/', psychologyController.getTips);
router.get('/:id', psychologyController.getTip);
router.post('/', psychologyController.createTip);

module.exports = router;
