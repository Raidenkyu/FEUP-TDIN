const jwt = require('jsonwebtoken');

function checkJWTandRole(role) {
    try {


        return checkJWTandRole[role] || (checkJWTandRole[role] = function (req, res, next) {
            const token = req.headers["auth_token"]

            if (!token) return res.status(401).json({ message: "No token provided" })

            const secret = process.env.CENTRAL_SERVER_SECRET;

            jwt.verify(token, secret, function (err, decoded) {
                if (err) return res.status(500).send({ auth: false, message: 'Failed to authenticate token.' });


                req.userEmail = decoded.email
                req.userName = decoded.name
                req.userRole = decoded.role
                if (!role.includes(decoded.role)) return res.status(401).json({ message: "Unauthorized" })


                next()
            })
        })
    } catch (e) {
        console.log(e)
    }
}

module.exports = checkJWTandRole