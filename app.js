const express = require('express')
const app = express()

app.use('/game', express.static('public'))

app.get('/', (req, res) => res.redirect('/game/index.html'))

app.listen(3000, () => console.log('Example app listening on port 3000!'))