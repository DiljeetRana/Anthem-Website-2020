﻿/************************************************
 * REVOLUTION 5.0 EXTENSION - SLIDE ANIMATIONS
 * @version: 1.0.5 (20.10.2015)
 * @requires jquery.themepunch.revolution.js
 * @author ThemePunch
************************************************/
!function () { var t = jQuery.fn.revolution; jQuery.extend(!0, t, { animateSlide: function (t, e, o, a, n, r, s, l, d) { return i(t, e, o, a, n, r, s, l, d) } }); var e = function (e, o, a, i) { var n = e, r = n.find(".defaultimg"), s = n.data("zoomstart"), l = n.data("rotationstart"); void 0 != r.data("currotate") && (l = r.data("currotate")), void 0 != r.data("curscale") && "box" == i ? s = 100 * r.data("curscale") : void 0 != r.data("curscale") && (s = r.data("curscale")), t.slotSize(r, o); var d = r.attr("src"), h = r.css("backgroundColor"), f = o.width, c = o.height, p = r.data("fxof"), u = 0; "on" == o.autoHeight && (c = o.c.height()), void 0 == p && (p = 0); var g = 0, w = r.data("bgfit"), v = r.data("bgrepeat"), m = r.data("bgposition"); switch (void 0 == w && (w = "cover"), void 0 == v && (v = "no-repeat"), void 0 == m && (m = "center center"), i) { case "box": var x = 0, y = 0, T = 0; if (x = o.sloth > o.slotw ? o.sloth : o.slotw, !a) var g = 0 - x; o.slotw = x, o.sloth = x; for (var y = 0, T = 0, z = 0; z < o.slots; z++) { T = 0; for (var L = 0; L < o.slots; L++)n.append('<div class="slot" style="position:absolute;top:' + (u + T) + "px;left:" + (p + y) + "px;width:" + x + "px;height:" + x + 'px;overflow:hidden;"><div class="slotslide" data-x="' + y + '" data-y="' + T + '" style="position:absolute;top:0px;left:0px;width:' + x + "px;height:" + x + 'px;overflow:hidden;"><div style="position:absolute;top:' + (0 - T) + "px;left:" + (0 - y) + "px;width:" + f + "px;height:" + c + "px;background-color:" + h + ";background-image:url(" + d + ");background-repeat:" + v + ";background-size:" + w + ";background-position:" + m + ';"></div></div></div>'), T += x, void 0 != s && void 0 != l && punchgs.TweenLite.set(n.find(".slot").last(), { rotationZ: l }); y += x } break; case "vertical": case "horizontal": if ("horizontal" == i) { if (!a) var g = 0 - o.slotw; for (var L = 0; L < o.slots; L++)n.append('<div class="slot" style="position:absolute;top:' + (0 + u) + "px;left:" + (p + L * o.slotw) + "px;overflow:hidden;width:" + (o.slotw + .6) + "px;height:" + c + 'px"><div class="slotslide" style="position:absolute;top:0px;left:' + g + "px;width:" + (o.slotw + .6) + "px;height:" + c + 'px;overflow:hidden;"><div style="background-color:' + h + ";position:absolute;top:0px;left:" + (0 - L * o.slotw) + "px;width:" + f + "px;height:" + c + "px;background-image:url(" + d + ");background-repeat:" + v + ";background-size:" + w + ";background-position:" + m + ';"></div></div></div>'), void 0 != s && void 0 != l && punchgs.TweenLite.set(n.find(".slot").last(), { rotationZ: l }) } else { if (!a) var g = 0 - o.sloth; for (var L = 0; L < o.slots + 2; L++)n.append('<div class="slot" style="position:absolute;top:' + (u + L * o.sloth) + "px;left:" + p + "px;overflow:hidden;width:" + f + "px;height:" + o.sloth + 'px"><div class="slotslide" style="position:absolute;top:' + g + "px;left:0px;width:" + f + "px;height:" + o.sloth + 'px;overflow:hidden;"><div style="background-color:' + h + ";position:absolute;top:" + (0 - L * o.sloth) + "px;left:0px;width:" + f + "px;height:" + c + "px;background-image:url(" + d + ");background-repeat:" + v + ";background-size:" + w + ";background-position:" + m + ';"></div></div></div>'), void 0 != s && void 0 != l && punchgs.TweenLite.set(n.find(".slot").last(), { rotationZ: l }) } } }, o = function (t, e, o, a, i) { function n() { jQuery.each(y, function (t, e) { (e[0] == o || e[8] == o) && (w = e[1], v = e[2], m = x), x += 1 }) } var r = punchgs.Power1.easeIn, s = punchgs.Power1.easeOut, l = punchgs.Power1.easeInOut, d = punchgs.Power2.easeIn, h = punchgs.Power2.easeOut, f = punchgs.Power2.easeInOut, c = (punchgs.Power3.easeIn, punchgs.Power3.easeOut), p = punchgs.Power3.easeInOut, u = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45], g = [16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 27], w = 0, v = 1, m = 0, x = 0, y = (new Array, [["boxslide", 0, 1, 10, 0, "box", !1, null, 0, s, s, 500, 6], ["boxfade", 1, 0, 10, 0, "box", !1, null, 1, l, l, 700, 5], ["slotslide-horizontal", 2, 0, 0, 200, "horizontal", !0, !1, 2, f, f, 700, 3], ["slotslide-vertical", 3, 0, 0, 200, "vertical", !0, !1, 3, f, f, 700, 3], ["curtain-1", 4, 3, 0, 0, "horizontal", !0, !0, 4, s, s, 300, 5], ["curtain-2", 5, 3, 0, 0, "horizontal", !0, !0, 5, s, s, 300, 5], ["curtain-3", 6, 3, 25, 0, "horizontal", !0, !0, 6, s, s, 300, 5], ["slotzoom-horizontal", 7, 0, 0, 400, "horizontal", !0, !0, 7, s, s, 300, 7], ["slotzoom-vertical", 8, 0, 0, 0, "vertical", !0, !0, 8, h, h, 500, 8], ["slotfade-horizontal", 9, 0, 0, 500, "horizontal", !0, null, 9, h, h, 500, 25], ["slotfade-vertical", 10, 0, 0, 500, "vertical", !0, null, 10, h, h, 500, 25], ["fade", 11, 0, 1, 300, "horizontal", !0, null, 11, f, f, 1e3, 1], ["crossfade", 11, 1, 1, 300, "horizontal", !0, null, 11, f, f, 1e3, 1], ["fadethroughdark", 11, 2, 1, 300, "horizontal", !0, null, 11, f, f, 1e3, 1], ["fadethroughlight", 11, 3, 1, 300, "horizontal", !0, null, 11, f, f, 1e3, 1], ["fadethroughtransparent", 11, 4, 1, 300, "horizontal", !0, null, 11, f, f, 1e3, 1], ["slideleft", 12, 0, 1, 0, "horizontal", !0, !0, 12, p, p, 1e3, 1], ["slideup", 13, 0, 1, 0, "horizontal", !0, !0, 13, p, p, 1e3, 1], ["slidedown", 14, 0, 1, 0, "horizontal", !0, !0, 14, p, p, 1e3, 1], ["slideright", 15, 0, 1, 0, "horizontal", !0, !0, 15, p, p, 1e3, 1], ["slideoverleft", 12, 7, 1, 0, "horizontal", !0, !0, 12, p, p, 1e3, 1], ["slideoverup", 13, 7, 1, 0, "horizontal", !0, !0, 13, p, p, 1e3, 1], ["slideoverdown", 14, 7, 1, 0, "horizontal", !0, !0, 14, p, p, 1e3, 1], ["slideoverright", 15, 7, 1, 0, "horizontal", !0, !0, 15, p, p, 1e3, 1], ["slideremoveleft", 12, 8, 1, 0, "horizontal", !0, !0, 12, p, p, 1e3, 1], ["slideremoveup", 13, 8, 1, 0, "horizontal", !0, !0, 13, p, p, 1e3, 1], ["slideremovedown", 14, 8, 1, 0, "horizontal", !0, !0, 14, p, p, 1e3, 1], ["slideremoveright", 15, 8, 1, 0, "horizontal", !0, !0, 15, p, p, 1e3, 1], ["papercut", 16, 0, 0, 600, "", null, null, 16, p, p, 1e3, 2], ["3dcurtain-horizontal", 17, 0, 20, 100, "vertical", !1, !0, 17, l, l, 500, 7], ["3dcurtain-vertical", 18, 0, 10, 100, "horizontal", !1, !0, 18, l, l, 500, 5], ["cubic", 19, 0, 20, 600, "horizontal", !1, !0, 19, p, p, 500, 1], ["cube", 19, 0, 20, 600, "horizontal", !1, !0, 20, p, p, 500, 1], ["flyin", 20, 0, 4, 600, "vertical", !1, !0, 21, c, p, 500, 1], ["turnoff", 21, 0, 1, 500, "horizontal", !1, !0, 22, p, p, 500, 1], ["incube", 22, 0, 20, 200, "horizontal", !1, !0, 23, f, f, 500, 1], ["cubic-horizontal", 23, 0, 20, 500, "vertical", !1, !0, 24, h, h, 500, 1], ["cube-horizontal", 23, 0, 20, 500, "vertical", !1, !0, 25, h, h, 500, 1], ["incube-horizontal", 24, 0, 20, 500, "vertical", !1, !0, 26, f, f, 500, 1], ["turnoff-vertical", 25, 0, 1, 200, "horizontal", !1, !0, 27, f, f, 500, 1], ["fadefromright", 12, 1, 1, 0, "horizontal", !0, !0, 28, f, f, 1e3, 1], ["fadefromleft", 15, 1, 1, 0, "horizontal", !0, !0, 29, f, f, 1e3, 1], ["fadefromtop", 14, 1, 1, 0, "horizontal", !0, !0, 30, f, f, 1e3, 1], ["fadefrombottom", 13, 1, 1, 0, "horizontal", !0, !0, 31, f, f, 1e3, 1], ["fadetoleftfadefromright", 12, 2, 1, 0, "horizontal", !0, !0, 32, f, f, 1e3, 1], ["fadetorightfadefromleft", 15, 2, 1, 0, "horizontal", !0, !0, 33, f, f, 1e3, 1], ["fadetobottomfadefromtop", 14, 2, 1, 0, "horizontal", !0, !0, 34, f, f, 1e3, 1], ["fadetotopfadefrombottom", 13, 2, 1, 0, "horizontal", !0, !0, 35, f, f, 1e3, 1], ["parallaxtoright", 12, 3, 1, 0, "horizontal", !0, !0, 36, f, d, 1500, 1], ["parallaxtoleft", 15, 3, 1, 0, "horizontal", !0, !0, 37, f, d, 1500, 1], ["parallaxtotop", 14, 3, 1, 0, "horizontal", !0, !0, 38, f, r, 1500, 1], ["parallaxtobottom", 13, 3, 1, 0, "horizontal", !0, !0, 39, f, r, 1500, 1], ["scaledownfromright", 12, 4, 1, 0, "horizontal", !0, !0, 40, f, d, 1e3, 1], ["scaledownfromleft", 15, 4, 1, 0, "horizontal", !0, !0, 41, f, d, 1e3, 1], ["scaledownfromtop", 14, 4, 1, 0, "horizontal", !0, !0, 42, f, d, 1e3, 1], ["scaledownfrombottom", 13, 4, 1, 0, "horizontal", !0, !0, 43, f, d, 1e3, 1], ["zoomout", 13, 5, 1, 0, "horizontal", !0, !0, 44, f, d, 1e3, 1], ["zoomin", 13, 6, 1, 0, "horizontal", !0, !0, 45, f, d, 1e3, 1], ["slidingoverlayup", 27, 0, 1, 0, "horizontal", !0, !0, 47, l, s, 2e3, 1], ["slidingoverlaydown", 28, 0, 1, 0, "horizontal", !0, !0, 48, l, s, 2e3, 1], ["slidingoverlayright", 30, 0, 1, 0, "horizontal", !0, !0, 49, l, s, 2e3, 1], ["slidingoverlayleft", 29, 0, 1, 0, "horizontal", !0, !0, 50, l, s, 2e3, 1], ["parallaxcirclesup", 31, 0, 1, 0, "horizontal", !0, !0, 51, f, r, 1500, 1], ["parallaxcirclesdown", 32, 0, 1, 0, "horizontal", !0, !0, 52, f, r, 1500, 1], ["parallaxcirclesright", 33, 0, 1, 0, "horizontal", !0, !0, 53, f, r, 1500, 1], ["parallaxcirclesleft", 34, 0, 1, 0, "horizontal", !0, !0, 54, f, r, 1500, 1], ["notransition", 26, 0, 1, 0, "horizontal", !0, null, 46, f, d, 1e3, 1], ["parallaxright", 12, 3, 1, 0, "horizontal", !0, !0, 55, f, d, 1500, 1], ["parallaxleft", 15, 3, 1, 0, "horizontal", !0, !0, 56, f, d, 1500, 1], ["parallaxup", 14, 3, 1, 0, "horizontal", !0, !0, 57, f, r, 1500, 1], ["parallaxdown", 13, 3, 1, 0, "horizontal", !0, !0, 58, f, r, 1500, 1]]); e.testanims = !1, 1 == e.testanims && (e.nexttesttransform = void 0 === e.nexttesttransform ? 34 : e.nexttesttransform + 1, e.nexttesttransform = e.nexttesttransform > 70 ? 0 : e.nexttesttransform, o = y[e.nexttesttransform][0], console.log(o + "  " + e.nexttesttransform + "  " + y[e.nexttesttransform][1] + "  " + y[e.nexttesttransform][2])), jQuery.each(["parallaxcircles", "slidingoverlay", "slide", "slideover", "slideremove", "parallax"], function (t, e) { o == e + "horizontal" && (o = 1 != i ? e + "left" : e + "right"), o == e + "vertical" && (o = 1 != i ? e + "up" : e + "down") }), "random" == o && (o = Math.round(Math.random() * y.length - 1), o > y.length - 1 && (o = y.length - 1)), "random-static" == o && (o = Math.round(Math.random() * u.length - 1), o > u.length - 1 && (o = u.length - 1), o = u[o]), "random-premium" == o && (o = Math.round(Math.random() * g.length - 1), o > g.length - 1 && (o = g.length - 1), o = g[o]); var T = [12, 13, 14, 15, 16, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45]; if (1 == e.isJoomla && void 0 != window.MooTools && -1 != T.indexOf(o)) { var z = Math.round(Math.random() * (g.length - 2)) + 1; z > g.length - 1 && (z = g.length - 1), 0 == z && (z = 1), o = g[z] } n(), w > 30 && (w = 30), 0 > w && (w = 0); var L = new Object; return L.nexttrans = w, L.STA = y[m], L.specials = v, L }, a = function (t, e) { return void 0 == e || jQuery.isNumeric(t) ? t : void 0 == t ? t : t.split(",")[e] }, i = function (t, i, n, r, s, l, d, h, f) { function c(t, e, o, a, i) { var n = t.find(".slot"), r = 6, s = [2, 1.2, .9, .7, .55, .42], l = t.width(), h = t.height(); n.wrap('<div class="slot-circle-wrapper" style="overflow:hidden;position:absolute;border:1px solid #fff"></div>'); for (var c = 0; r > c; c++)n.parent().clone(!1).appendTo(d); t.find(".slot-circle-wrapper").each(function (t) { if (r > t) { var a = jQuery(this), n = a.find(".slot"), d = l > h ? s[t] * l : s[t] * h, c = d, p = 0 + (c / 2 - l / 2), u = 0 + (d / 2 - h / 2), g = 0 != t ? "50%" : "0", w = 31 == o ? h / 2 - d / 2 : 32 == o ? h / 2 - d / 2 : h / 2 - d / 2, v = 33 == o ? l / 2 - c / 2 : 34 == o ? l - c : l / 2 - c / 2, m = { scale: 1, transformOrigo: "50% 50%", width: c + "px", height: d + "px", top: w + "px", left: v + "px", borderRadius: g }, x = { scale: 1, top: h / 2 - d / 2, left: l / 2 - c / 2, ease: i }, y = 31 == o ? u : 32 == o ? u : u, T = 33 == o ? p : 34 == o ? p + l / 2 : p, z = { width: l, height: h, autoAlpha: 1, top: y + "px", position: "absolute", left: T + "px" }, L = { top: u + "px", left: p + "px", ease: i }, b = e, D = 0; f.add(punchgs.TweenLite.fromTo(a, b, m, x), D), f.add(punchgs.TweenLite.fromTo(n, b, z, L), D), f.add(punchgs.TweenLite.fromTo(a, .001, { autoAlpha: 0 }, { autoAlpha: 1 }), 0) } }) } var p = l.index(), u = s.index(), g = p > u ? 1 : 0; "arrow" == r.sc_indicator && (g = r.sc_indicator_dir); var w = o(n, r, i, d, g), v = w.STA, m = w.specials, t = w.nexttrans; "on" == d.data("kenburns") && (t = 11); var x = s.data("nexttransid") || 0, y = a(s.data("masterspeed"), x); y = "default" === y ? v[11] : "random" === y ? Math.round(1e3 * Math.random() + 300) : void 0 != y ? parseInt(y, 0) : v[11], y = y > r.delay ? r.delay : y, y += v[4], r.slots = a(s.data("slotamount"), x), r.slots = void 0 == r.slots || "default" == r.slots ? v[12] : "random" == r.slots ? Math.round(12 * Math.random() + 4) : v[12], r.slots = r.slots < 1 ? "boxslide" == i ? Math.round(6 * Math.random() + 3) : "flyin" == i ? Math.round(4 * Math.random() + 1) : r.slots : r.slots, r.slots = (4 == t || 5 == t || 6 == t) && r.slots < 3 ? 3 : r.slots, r.slots = 0 != v[3] ? Math.min(r.slots, v[3]) : r.slots, r.slots = 9 == t ? r.width / 20 : 10 == t ? r.height / 20 : r.slots, r.rotate = a(s.data("rotate"), x), r.rotate = void 0 == r.rotate || "default" == r.rotate ? 0 : 999 == r.rotate || "random" == r.rotate ? Math.round(360 * Math.random()) : r.rotate, r.rotate = !jQuery.support.transition || r.ie || r.ie9 ? 0 : r.rotate, 11 != t && (null != v[7] && e(h, r, v[7], v[5]), null != v[6] && e(d, r, v[6], v[5])), f.add(punchgs.TweenLite.set(d.find(".defaultvid"), { y: 0, x: 0, top: 0, left: 0, scale: 1 }), 0), f.add(punchgs.TweenLite.set(h.find(".defaultvid"), { y: 0, x: 0, top: 0, left: 0, scale: 1 }), 0), f.add(punchgs.TweenLite.set(d.find(".defaultvid"), { y: "+0%", x: "+0%" }), 0), f.add(punchgs.TweenLite.set(h.find(".defaultvid"), { y: "+0%", x: "+0%" }), 0), f.add(punchgs.TweenLite.set(d, { autoAlpha: 1, y: "+0%", x: "+0%" }), 0), f.add(punchgs.TweenLite.set(h, { autoAlpha: 1, y: "+0%", x: "+0%" }), 0), f.add(punchgs.TweenLite.set(d.parent(), { backgroundColor: "transparent" }), 0), f.add(punchgs.TweenLite.set(h.parent(), { backgroundColor: "transparent" }), 0); var T = a(s.data("easein"), x), z = a(s.data("easeout"), x); if (T = "default" === T ? v[9] || punchgs.Power2.easeInOut : T || v[9] || punchgs.Power2.easeInOut, z = "default" === z ? v[10] || punchgs.Power2.easeInOut : z || v[10] || punchgs.Power2.easeInOut, 0 == t) { var L = Math.ceil(r.height / r.sloth), b = 0; d.find(".slotslide").each(function (t) { var e = jQuery(this); b += 1, b == L && (b = 0), f.add(punchgs.TweenLite.from(e, y / 600, { opacity: 0, top: 0 - r.sloth, left: 0 - r.slotw, rotation: r.rotate, force3D: "auto", ease: T }), (15 * t + 30 * b) / 1500) }) } if (1 == t) { var D, A = 0; d.find(".slotslide").each(function (t) { var e = jQuery(this), o = Math.random() * y + 300, a = 500 * Math.random() + 200; o + a > D && (D = a + a, A = t), f.add(punchgs.TweenLite.from(e, o / 1e3, { autoAlpha: 0, force3D: "auto", rotation: r.rotate, ease: T }), a / 1e3) }) } if (2 == t) { var j = new punchgs.TimelineLite; h.find(".slotslide").each(function () { var t = jQuery(this); j.add(punchgs.TweenLite.to(t, y / 1e3, { left: r.slotw, ease: T, force3D: "auto", rotation: 0 - r.rotate }), 0), f.add(j, 0) }), d.find(".slotslide").each(function () { var t = jQuery(this); j.add(punchgs.TweenLite.from(t, y / 1e3, { left: 0 - r.slotw, ease: T, force3D: "auto", rotation: r.rotate }), 0), f.add(j, 0) }) } if (3 == t) { var j = new punchgs.TimelineLite; h.find(".slotslide").each(function () { var t = jQuery(this); j.add(punchgs.TweenLite.to(t, y / 1e3, { top: r.sloth, ease: T, rotation: r.rotate, force3D: "auto", transformPerspective: 600 }), 0), f.add(j, 0) }), d.find(".slotslide").each(function () { var t = jQuery(this); j.add(punchgs.TweenLite.from(t, y / 1e3, { top: 0 - r.sloth, rotation: r.rotate, ease: z, force3D: "auto", transformPerspective: 600 }), 0), f.add(j, 0) }) } if (4 == t || 5 == t) { setTimeout(function () { h.find(".defaultimg").css({ opacity: 0 }) }, 100); var k = y / 1e3, j = new punchgs.TimelineLite; h.find(".slotslide").each(function (e) { var o = jQuery(this), a = e * k / r.slots; 5 == t && (a = (r.slots - e - 1) * k / r.slots / 1.5), j.add(punchgs.TweenLite.to(o, 3 * k, { transformPerspective: 600, force3D: "auto", top: 0 + r.height, opacity: .5, rotation: r.rotate, ease: T, delay: a }), 0), f.add(j, 0) }), d.find(".slotslide").each(function (e) { var o = jQuery(this), a = e * k / r.slots; 5 == t && (a = (r.slots - e - 1) * k / r.slots / 1.5), j.add(punchgs.TweenLite.from(o, 3 * k, { top: 0 - r.height, opacity: .5, rotation: r.rotate, force3D: "auto", ease: punchgs.eo, delay: a }), 0), f.add(j, 0) }) } if (6 == t) { r.slots < 2 && (r.slots = 2), r.slots % 2 && (r.slots = r.slots + 1); var j = new punchgs.TimelineLite; setTimeout(function () { h.find(".defaultimg").css({ opacity: 0 }) }, 100), h.find(".slotslide").each(function (t) { var e = jQuery(this); if (t + 1 < r.slots / 2) var o = 90 * (t + 2); else var o = 90 * (2 + r.slots - t); j.add(punchgs.TweenLite.to(e, (y + o) / 1e3, { top: 0 + r.height, opacity: 1, force3D: "auto", rotation: r.rotate, ease: T }), 0), f.add(j, 0) }), d.find(".slotslide").each(function (t) { var e = jQuery(this); if (t + 1 < r.slots / 2) var o = 90 * (t + 2); else var o = 90 * (2 + r.slots - t); j.add(punchgs.TweenLite.from(e, (y + o) / 1e3, { top: 0 - r.height, opacity: 1, force3D: "auto", rotation: r.rotate, ease: z }), 0), f.add(j, 0) }) } if (7 == t) { y = 2 * y, y > r.delay && (y = r.delay); var j = new punchgs.TimelineLite; setTimeout(function () { h.find(".defaultimg").css({ opacity: 0 }) }, 100), h.find(".slotslide").each(function () { var t = jQuery(this).find("div"); j.add(punchgs.TweenLite.to(t, y / 1e3, { left: 0 - r.slotw / 2 + "px", top: 0 - r.height / 2 + "px", width: 2 * r.slotw + "px", height: 2 * r.height + "px", opacity: 0, rotation: r.rotate, force3D: "auto", ease: T }), 0), f.add(j, 0) }), d.find(".slotslide").each(function (t) { var e = jQuery(this).find("div"); j.add(punchgs.TweenLite.fromTo(e, y / 1e3, { left: 0, top: 0, opacity: 0, transformPerspective: 600 }, { left: 0 - t * r.slotw + "px", ease: z, force3D: "auto", top: "0px", width: r.width, height: r.height, opacity: 1, rotation: 0, delay: .1 }), 0), f.add(j, 0) }) } if (8 == t) { y = 3 * y, y > r.delay && (y = r.delay); var j = new punchgs.TimelineLite; h.find(".slotslide").each(function () { var t = jQuery(this).find("div"); j.add(punchgs.TweenLite.to(t, y / 1e3, { left: 0 - r.width / 2 + "px", top: 0 - r.sloth / 2 + "px", width: 2 * r.width + "px", height: 2 * r.sloth + "px", force3D: "auto", ease: T, opacity: 0, rotation: r.rotate }), 0), f.add(j, 0) }), d.find(".slotslide").each(function (t) { var e = jQuery(this).find("div"); j.add(punchgs.TweenLite.fromTo(e, y / 1e3, { left: 0, top: 0, opacity: 0, force3D: "auto" }, { left: "0px", top: 0 - t * r.sloth + "px", width: d.find(".defaultimg").data("neww") + "px", height: d.find(".defaultimg").data("newh") + "px", opacity: 1, ease: z, rotation: 0 }), 0), f.add(j, 0) }) } if (9 == t || 10 == t) { var M = 0; d.find(".slotslide").each(function (t) { var e = jQuery(this); M++ , f.add(punchgs.TweenLite.fromTo(e, y / 1e3, { autoAlpha: 0, force3D: "auto", transformPerspective: 600 }, { autoAlpha: 1, ease: T, delay: 5 * t / 1e3 }), 0) }) } if (27 == t || 28 == t || 29 == t || 30 == t) { var P = d.find(".slot"), Q = 27 == t || 28 == t ? 1 : 2, O = 27 == t || 29 == t ? "-100%" : "+100%", I = 27 == t || 29 == t ? "+100%" : "-100%", X = 27 == t || 29 == t ? "-80%" : "80%", Y = 27 == t || 29 == t ? "80%" : "-80%", S = 27 == t || 29 == t ? "10%" : "-10%", _ = { overwrite: "all" }, C = { autoAlpha: 0, zIndex: 1, force3D: "auto", ease: T }, V = { position: "inherit", autoAlpha: 0, overwrite: "all", zIndex: 1 }, Z = { autoAlpha: 1, force3D: "auto", ease: z }, H = { overwrite: "all", zIndex: 2 }, J = { autoAlpha: 1, force3D: "auto", overwrite: "all", ease: T }, N = { overwrite: "all", zIndex: 2 }, R = { autoAlpha: 1, force3D: "auto", ease: T }, q = 1 == Q ? "y" : "x"; _[q] = "0px", C[q] = O, V[q] = S, Z[q] = "0%", H[q] = I, J[q] = O, N[q] = X, R[q] = Y, P.append('<span style="background-color:rgba(0,0,0,0.6);width:100%;height:100%;position:absolute;top:0px;left:0px;display:block;z-index:2"></span>'), f.add(punchgs.TweenLite.fromTo(h, y / 1e3, _, C), 0), f.add(punchgs.TweenLite.fromTo(d.find(".defaultimg"), y / 2e3, V, Z), y / 2e3), f.add(punchgs.TweenLite.fromTo(P, y / 1e3, H, J), 0), f.add(punchgs.TweenLite.fromTo(P.find(".slotslide div"), y / 1e3, N, R), 0) } if (31 == t || 32 == t || 33 == t || 34 == t) { y = 6e3, T = punchgs.Power3.easeInOut; var B = y / 1e3; mas = B - B / 5, _nt = t, fy = 31 == _nt ? "+100%" : 32 == _nt ? "-100%" : "0%", fx = 33 == _nt ? "+100%" : 34 == _nt ? "-100%" : "0%", ty = 31 == _nt ? "-100%" : 32 == _nt ? "+100%" : "0%", tx = 33 == _nt ? "-100%" : 34 == _nt ? "+100%" : "0%", f.add(punchgs.TweenLite.fromTo(h, B - .2 * B, { y: 0, x: 0 }, { y: ty, x: tx, ease: z }), .2 * B), f.add(punchgs.TweenLite.fromTo(d, B, { y: fy, x: fx }, { y: "0%", x: "0%", ease: T }), 0), d.find(".slot").remove(), d.find(".defaultimg").clone().appendTo(d).addClass("slot"), c(d, B, _nt, "in", T) } if (11 == t) { m > 4 && (m = 0); var M = 0, E = 2 == m ? "#000000" : 3 == m ? "#ffffff" : "transparent"; switch (m) { case 0: f.add(punchgs.TweenLite.fromTo(d, y / 1e3, { autoAlpha: 0 }, { autoAlpha: 1, force3D: "auto", ease: T }), 0); break; case 1: f.add(punchgs.TweenLite.fromTo(d, y / 1e3, { autoAlpha: 0 }, { autoAlpha: 1, force3D: "auto", ease: T }), 0), f.add(punchgs.TweenLite.fromTo(h, y / 1e3, { autoAlpha: 1 }, { autoAlpha: 0, force3D: "auto", ease: T }), 0); break; case 2: case 3: case 4: f.add(punchgs.TweenLite.set(h.parent(), { backgroundColor: E, force3D: "auto" }), 0), f.add(punchgs.TweenLite.set(d.parent(), { backgroundColor: "transparent", force3D: "auto" }), 0), f.add(punchgs.TweenLite.to(h, y / 2e3, { autoAlpha: 0, force3D: "auto", ease: T }), 0), f.add(punchgs.TweenLite.fromTo(d, y / 2e3, { autoAlpha: 0 }, { autoAlpha: 1, force3D: "auto", ease: T }), y / 2e3) }f.add(punchgs.TweenLite.set(d.find(".defaultimg"), { autoAlpha: 1 }), 0), f.add(punchgs.TweenLite.set(h.find("defaultimg"), { autoAlpha: 1 }), 0) } if (26 == t) { var M = 0; y = 0, f.add(punchgs.TweenLite.fromTo(d, y / 1e3, { autoAlpha: 0 }, { autoAlpha: 1, force3D: "auto", ease: T }), 0), f.add(punchgs.TweenLite.to(h, y / 1e3, { autoAlpha: 0, force3D: "auto", ease: T }), 0), f.add(punchgs.TweenLite.set(d.find(".defaultimg"), { autoAlpha: 1 }), 0), f.add(punchgs.TweenLite.set(h.find("defaultimg"), { autoAlpha: 1 }), 0) } if (12 == t || 13 == t || 14 == t || 15 == t) { y = y, y > r.delay && (y = r.delay), setTimeout(function () { punchgs.TweenLite.set(h.find(".defaultimg"), { autoAlpha: 0 }) }, 100); var F = r.width, G = r.height, K = d.find(".slotslide, .defaultvid"), U = 0, W = 0, $ = 1, te = 1, ee = 1, oe = y / 1e3, ae = oe; ("fullwidth" == r.sliderLayout || "fullscreen" == r.sliderLayout) && (F = K.width(), G = K.height()), 12 == t ? U = F : 15 == t ? U = 0 - F : 13 == t ? W = G : 14 == t && (W = 0 - G), 1 == m && ($ = 0), 2 == m && ($ = 0), 3 == m && (oe = y / 1300), (4 == m || 5 == m) && (te = .6), 6 == m && (te = 1.4), (5 == m || 6 == m) && (ee = 1.4, $ = 0, F = 0, G = 0, U = 0, W = 0), 6 == m && (ee = .6); 7 == m && (F = 0, G = 0); var ie = d.find(".slotslide"), ne = h.find(".slotslide, .defaultvid"); if (f.add(punchgs.TweenLite.set(l, { zIndex: 15 }), 0), f.add(punchgs.TweenLite.set(s, { zIndex: 20 }), 0), 8 == m ? (f.add(punchgs.TweenLite.set(l, { zIndex: 20 }), 0), f.add(punchgs.TweenLite.set(s, { zIndex: 15 }), 0), f.add(punchgs.TweenLite.set(ie, { left: 0, top: 0, scale: 1, opacity: 1, rotation: 0, ease: T, force3D: "auto" }), 0)) : f.add(punchgs.TweenLite.from(ie, oe, { left: U, top: W, scale: ee, opacity: $, rotation: r.rotate, ease: T, force3D: "auto" }), 0), (4 == m || 5 == m) && (F = 0, G = 0), 1 != m) switch (t) { case 12: f.add(punchgs.TweenLite.to(ne, ae, { left: 0 - F + "px", force3D: "auto", scale: te, opacity: $, rotation: r.rotate, ease: z }), 0); break; case 15: f.add(punchgs.TweenLite.to(ne, ae, { left: F + "px", force3D: "auto", scale: te, opacity: $, rotation: r.rotate, ease: z }), 0); break; case 13: f.add(punchgs.TweenLite.to(ne, ae, { top: 0 - G + "px", force3D: "auto", scale: te, opacity: $, rotation: r.rotate, ease: z }), 0); break; case 14: f.add(punchgs.TweenLite.to(ne, ae, { top: G + "px", force3D: "auto", scale: te, opacity: $, rotation: r.rotate, ease: z }), 0) } } if (16 == t) { var j = new punchgs.TimelineLite; f.add(punchgs.TweenLite.set(l, { position: "absolute", "z-index": 20 }), 0), f.add(punchgs.TweenLite.set(s, { position: "absolute", "z-index": 15 }), 0), l.wrapInner('<div class="tp-half-one" style="position:relative; width:100%;height:100%"></div>'), l.find(".tp-half-one").clone(!0).appendTo(l).addClass("tp-half-two"), l.find(".tp-half-two").removeClass("tp-half-one"); var F = r.width, G = r.height; "on" == r.autoHeight && (G = n.height()), l.find(".tp-half-one .defaultimg").wrap('<div class="tp-papercut" style="width:' + F + "px;height:" + G + 'px;"></div>'), l.find(".tp-half-two .defaultimg").wrap('<div class="tp-papercut" style="width:' + F + "px;height:" + G + 'px;"></div>'), l.find(".tp-half-two .defaultimg").css({ position: "absolute", top: "-50%" }), l.find(".tp-half-two .tp-caption").wrapAll('<div style="position:absolute;top:-50%;left:0px;"></div>'), f.add(punchgs.TweenLite.set(l.find(".tp-half-two"), { width: F, height: G, overflow: "hidden", zIndex: 15, position: "absolute", top: G / 2, left: "0px", transformPerspective: 600, transformOrigin: "center bottom" }), 0), f.add(punchgs.TweenLite.set(l.find(".tp-half-one"), { width: F, height: G / 2, overflow: "visible", zIndex: 10, position: "absolute", top: "0px", left: "0px", transformPerspective: 600, transformOrigin: "center top" }), 0); var re = (l.find(".defaultimg"), Math.round(20 * Math.random() - 10)), se = Math.round(20 * Math.random() - 10), le = Math.round(20 * Math.random() - 10), de = .4 * Math.random() - .2, he = .4 * Math.random() - .2, fe = 1 * Math.random() + 1, ce = 1 * Math.random() + 1, pe = .3 * Math.random() + .3; f.add(punchgs.TweenLite.set(l.find(".tp-half-one"), { overflow: "hidden" }), 0), f.add(punchgs.TweenLite.fromTo(l.find(".tp-half-one"), y / 800, { width: F, height: G / 2, position: "absolute", top: "0px", left: "0px", force3D: "auto", transformOrigin: "center top" }, { scale: fe, rotation: re, y: 0 - G - G / 4, autoAlpha: 0, ease: T }), 0), f.add(punchgs.TweenLite.fromTo(l.find(".tp-half-two"), y / 800, { width: F, height: G, overflow: "hidden", position: "absolute", top: G / 2, left: "0px", force3D: "auto", transformOrigin: "center bottom" }, { scale: ce, rotation: se, y: G + G / 4, ease: T, autoAlpha: 0, onComplete: function () { punchgs.TweenLite.set(l, { position: "absolute", "z-index": 15 }), punchgs.TweenLite.set(s, { position: "absolute", "z-index": 20 }), l.find(".tp-half-one").length > 0 && (l.find(".tp-half-one .defaultimg").unwrap(), l.find(".tp-half-one .slotholder").unwrap()), l.find(".tp-half-two").remove() } }), 0), j.add(punchgs.TweenLite.set(d.find(".defaultimg"), { autoAlpha: 1 }), 0), null != l.html() && f.add(punchgs.TweenLite.fromTo(s, (y - 200) / 1e3, { scale: pe, x: r.width / 4 * de, y: G / 4 * he, rotation: le, force3D: "auto", transformOrigin: "center center", ease: z }, { autoAlpha: 1, scale: 1, x: 0, y: 0, rotation: 0 }), 0), f.add(j, 0) } if (17 == t && d.find(".slotslide").each(function (t) { var e = jQuery(this); f.add(punchgs.TweenLite.fromTo(e, y / 800, { opacity: 0, rotationY: 0, scale: .9, rotationX: -110, force3D: "auto", transformPerspective: 600, transformOrigin: "center center" }, { opacity: 1, top: 0, left: 0, scale: 1, rotation: 0, rotationX: 0, force3D: "auto", rotationY: 0, ease: T, delay: .06 * t }), 0) }), 18 == t && d.find(".slotslide").each(function (t) { var e = jQuery(this); f.add(punchgs.TweenLite.fromTo(e, y / 500, { autoAlpha: 0, rotationY: 110, scale: .9, rotationX: 10, force3D: "auto", transformPerspective: 600, transformOrigin: "center center" }, { autoAlpha: 1, top: 0, left: 0, scale: 1, rotation: 0, rotationX: 0, force3D: "auto", rotationY: 0, ease: T, delay: .06 * t }), 0) }), 19 == t || 22 == t) { var j = new punchgs.TimelineLite; f.add(punchgs.TweenLite.set(l, { zIndex: 20 }), 0), f.add(punchgs.TweenLite.set(s, { zIndex: 20 }), 0), setTimeout(function () { h.find(".defaultimg").css({ opacity: 0 }) }, 100); var ue = 90, $ = 1, ge = "center center "; 1 == g && (ue = -90), 19 == t ? (ge = ge + "-" + r.height / 2, $ = 0) : ge += r.height / 2, punchgs.TweenLite.set(n, { transformStyle: "flat", backfaceVisibility: "hidden", transformPerspective: 600 }), d.find(".slotslide").each(function (t) { var e = jQuery(this); j.add(punchgs.TweenLite.fromTo(e, y / 1e3, { transformStyle: "flat", backfaceVisibility: "hidden", left: 0, rotationY: r.rotate, z: 10, top: 0, scale: 1, force3D: "auto", transformPerspective: 600, transformOrigin: ge, rotationX: ue }, { left: 0, rotationY: 0, top: 0, z: 0, scale: 1, force3D: "auto", rotationX: 0, delay: 50 * t / 1e3, ease: T }), 0), j.add(punchgs.TweenLite.to(e, .1, { autoAlpha: 1, delay: 50 * t / 1e3 }), 0), f.add(j) }), h.find(".slotslide").each(function (t) { var e = jQuery(this), o = -90; 1 == g && (o = 90), j.add(punchgs.TweenLite.fromTo(e, y / 1e3, { transformStyle: "flat", backfaceVisibility: "hidden", autoAlpha: 1, rotationY: 0, top: 0, z: 0, scale: 1, force3D: "auto", transformPerspective: 600, transformOrigin: ge, rotationX: 0 }, { autoAlpha: 1, rotationY: r.rotate, top: 0, z: 10, scale: 1, rotationX: o, delay: 50 * t / 1e3, force3D: "auto", ease: z }), 0), f.add(j) }), f.add(punchgs.TweenLite.set(l, { zIndex: 18 }), 0) } if (20 == t) { if (setTimeout(function () { h.find(".defaultimg").css({ opacity: 0 }) }, 100), 1 == g) var we = -r.width, ue = 80, ge = "20% 70% -" + r.height / 2; else var we = r.width, ue = -80, ge = "80% 70% -" + r.height / 2; d.find(".slotslide").each(function (t) { var e = jQuery(this), o = 50 * t / 1e3; f.add(punchgs.TweenLite.fromTo(e, y / 1e3, { left: we, rotationX: 40, z: -600, opacity: $, top: 0, scale: 1, force3D: "auto", transformPerspective: 600, transformOrigin: ge, transformStyle: "flat", rotationY: ue }, { left: 0, rotationX: 0, opacity: 1, top: 0, z: 0, scale: 1, rotationY: 0, delay: o, ease: T }), 0) }), h.find(".slotslide").each(function (t) { var e = jQuery(this), o = 50 * t / 1e3; if (o = t > 0 ? o + y / 9e3 : 0, 1 != g) var a = -r.width / 2, i = 30, n = "20% 70% -" + r.height / 2; else var a = r.width / 2, i = -30, n = "80% 70% -" + r.height / 2; z = punchgs.Power2.easeInOut, f.add(punchgs.TweenLite.fromTo(e, y / 1e3, { opacity: 1, rotationX: 0, top: 0, z: 0, scale: 1, left: 0, force3D: "auto", transformPerspective: 600, transformOrigin: n, transformStyle: "flat", rotationY: 0 }, { opacity: 1, rotationX: 20, top: 0, z: -600, left: a, force3D: "auto", rotationY: i, delay: o, ease: z }), 0) }) } if (21 == t || 25 == t) { setTimeout(function () { h.find(".defaultimg").css({ opacity: 0 }) }, 100); var ue = 90, we = -r.width, ve = -ue; if (1 == g) if (25 == t) { var ge = "center top 0"; ue = r.rotate } else { var ge = "left center 0"; ve = r.rotate } else if (we = r.width, ue = -90, 25 == t) { var ge = "center bottom 0"; ve = -ue, ue = r.rotate } else { var ge = "right center 0"; ve = r.rotate } d.find(".slotslide").each(function () { var t = jQuery(this), e = y / 1.5 / 3; f.add(punchgs.TweenLite.fromTo(t, 2 * e / 1e3, { left: 0, transformStyle: "flat", rotationX: ve, z: 0, autoAlpha: 0, top: 0, scale: 1, force3D: "auto", transformPerspective: 1200, transformOrigin: ge, rotationY: ue }, { left: 0, rotationX: 0, top: 0, z: 0, autoAlpha: 1, scale: 1, rotationY: 0, force3D: "auto", delay: e / 1e3, ease: T }), 0) }), 1 != g ? (we = -r.width, ue = 90, 25 == t ? (ge = "center top 0", ve = -ue, ue = r.rotate) : (ge = "left center 0", ve = r.rotate)) : (we = r.width, ue = -90, 25 == t ? (ge = "center bottom 0", ve = -ue, ue = r.rotate) : (ge = "right center 0", ve = r.rotate)), h.find(".slotslide").each(function () { var t = jQuery(this); f.add(punchgs.TweenLite.fromTo(t, y / 1e3, { left: 0, transformStyle: "flat", rotationX: 0, z: 0, autoAlpha: 1, top: 0, scale: 1, force3D: "auto", transformPerspective: 1200, transformOrigin: ge, rotationY: 0 }, { left: 0, rotationX: ve, top: 0, z: 0, autoAlpha: 1, force3D: "auto", scale: 1, rotationY: ue, ease: z }), 0) }) } if (23 == t || 24 == t) { setTimeout(function () { h.find(".defaultimg").css({ opacity: 0 }) }, 100); var ue = -90, $ = 1, me = 0; if (1 == g && (ue = 90), 23 == t) { var ge = "center center -" + r.width / 2; $ = 0 } else var ge = "center center " + r.width / 2; punchgs.TweenLite.set(n, { transformStyle: "preserve-3d", backfaceVisibility: "hidden", perspective: 2500 }), d.find(".slotslide").each(function (t) { var e = jQuery(this); f.add(punchgs.TweenLite.fromTo(e, y / 1e3, { left: me, rotationX: r.rotate, force3D: "auto", opacity: $, top: 0, scale: 1, transformPerspective: 1200, transformOrigin: ge, rotationY: ue }, { left: 0, rotationX: 0, autoAlpha: 1, top: 0, z: 0, scale: 1, rotationY: 0, delay: 50 * t / 500, ease: T }), 0) }), ue = 90, 1 == g && (ue = -90), h.find(".slotslide").each(function (e) { var o = jQuery(this); f.add(punchgs.TweenLite.fromTo(o, y / 1e3, { left: 0, rotationX: 0, top: 0, z: 0, scale: 1, force3D: "auto", transformStyle: "flat", transformPerspective: 1200, transformOrigin: ge, rotationY: 0 }, { left: me, rotationX: r.rotate, top: 0, scale: 1, rotationY: ue, delay: 50 * e / 500, ease: z }), 0), 23 == t && f.add(punchgs.TweenLite.fromTo(o, y / 2e3, { autoAlpha: 1 }, { autoAlpha: 0, delay: 50 * e / 500 + y / 3e3, ease: z }), 0) }) } return f } }(jQuery);