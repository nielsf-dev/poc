package org.nelis.mvcpoc.web

import org.springframework.stereotype.Controller
import org.springframework.ui.Model
import org.springframework.web.bind.annotation.GetMapping

@Controller
class PersoonController {

    @GetMapping("/persoon")
    fun getPersoon(model: Model) : String{
        model.addAttribute("naam","Nelis")
        return "persoon"
    }
}